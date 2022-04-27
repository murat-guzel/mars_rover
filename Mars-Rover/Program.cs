using Mars_Rover.Domain.Concrete;
using Mars_Rover.Domain.Models;
using Mars_Rover.Enums;
using Mars_Rover.Exceptions;
using Mars_Rover.Logger;
using Mars_Rover.Repository;
using Mars_Rover.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
             

            // Get Configuration
            IConfiguration Configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .AddCommandLine(args)
                   .Build();

            //setup DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IRepository<RoverLog>, Repository<RoverLog>>()
                .AddSingleton<ILogger, ConsoleLogger>()
                .AddEntityFrameworkNpgsql().AddDbContext<MarsRoverContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();



            var _logger = serviceProvider.GetService<ILogger>();
            var _loggerRepo = serviceProvider.GetService<IRepository<RoverLog>>();
      

            try
            {

                Console.WriteLine("Press ESC to see expected output");
                var plateuLines = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                if (plateuLines.Count !=2 || plateuLines[0] < 0 || plateuLines[1] < 0)
                    throw new InvalidParameterException("Plateu is invalid");

                Plateau plateau = new Plateau();
                plateau.Width = plateuLines[0];
                plateau.Height = plateuLines[1];

                List<string> output = new List<string>();

                while (!Console.KeyAvailable && Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    var currentCoordinate = Console.ReadLine().Trim().Split(' ');


                    Direction direction = (Direction)Enum.Parse(typeof(Direction), currentCoordinate[2], true);
                    Coordinate coordinate = new Coordinate(Convert.ToInt32(currentCoordinate[0]), Convert.ToInt32(currentCoordinate[1]), direction);

                    CoordinateValidator coordinateValidator = new CoordinateValidator(coordinate);
                    if (!coordinateValidator.Validate(coordinate).IsValid)
                        throw new InvalidParameterException("Coordinate is invalid");

                    Rover rover = new Rover(coordinate, plateau,_loggerRepo);

                    string directions = Console.ReadLine();

                    RoverCommand rovercommand = new RoverCommand();
                    rovercommand.rover = rover;

                    List<Motion> motionList = new List<Motion>();
                    foreach (char directionEvent in directions)
                    {
                        if (directionEvent == 'L')
                            motionList.Add(Motion.TurnLeft);
                        else if (directionEvent == 'R')
                            motionList.Add(Motion.TurnRight);
                        else if (directionEvent == 'M')
                            motionList.Add(Motion.Move);
                        else
                            throw new InvalidParameterException("Motion is invalid");
                    }

                    rovercommand.CommandList = motionList;
                    rovercommand.ExecuteAction();
                    output.Add(rover.X + " " + rover.Y + " " + rover.direction);
                }


                foreach (var item in output)
                {
                    Console.WriteLine(item);
                }

            }
            catch (Exception ex)
            {

                throw new InvalidParameterException("General error");
            }
        }

    }
}
