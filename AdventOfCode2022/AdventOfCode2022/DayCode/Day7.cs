using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayCode
{
    internal class Day7 : IDayCode
    {
        public void RunDay(string input)
        {
            var commands = input.Split('\n');
            FileStructure rootDrive = new FileStructure()
            {
                Name = "/",
                Size = null,
                Parent = null,
            };
            FileStructure activeDirectory = rootDrive;

            foreach (var command in commands.Skip(1))
            {
                if (command.Contains("$ ls")) continue;
                else if (command.Contains("cd ..")) activeDirectory = activeDirectory.Parent;
                else if (command.Contains("cd ")) activeDirectory = activeDirectory.Children.First(x => x.Name == command.Split(' ').Last());
                else if (command.Contains("dir ")) activeDirectory.Children.Add(new FileStructure()
                {
                    Name = command.Split(' ').Last(),
                    Parent = activeDirectory,
                    Size = null
                });
                else
                {
                    activeDirectory.Children.Add(new FileStructure()
                    {
                        Name = command.Split(' ').Last(),
                        Size = int.Parse(command.Split(' ').First()),
                        Children = null,
                        Parent = activeDirectory
                    });
                }
            }

            activeDirectory = rootDrive;
            var smallDirectoryTotal = 0;
            SumSmallDirectorySizes(activeDirectory, ref smallDirectoryTotal);
            Console.WriteLine($"Total size of folders under 100k is {smallDirectoryTotal}");

            var deletionCandidates = FindDeletionCandidates(rootDrive, new List<FileStructure>(), 30000000 - (70000000 - rootDrive.GetSize));
            Console.WriteLine($"Delete folder {deletionCandidates.OrderBy(x => x.GetSize).First().Name} with file size {deletionCandidates.OrderBy(x => x.GetSize).First().GetSize}");
            Console.ReadKey();
            
        }

        public void SumSmallDirectorySizes(FileStructure directory, ref int runningTotal)
        {
            foreach (var dir in directory.Children.Where(x => x.Children != null))
            {
                if (dir.GetSize < 100000) runningTotal += dir.GetSize;
                SumSmallDirectorySizes(dir, ref runningTotal);
            }
        }

        public List<FileStructure> FindDeletionCandidates(FileStructure directory, List<FileStructure> candidateList, int minRequiredSize)
        {
            foreach (var dir in directory.Children.Where(x => x.Children != null))
            {
                if (dir.GetSize >= minRequiredSize) candidateList.Add(dir);
                FindDeletionCandidates(dir, candidateList, minRequiredSize);
            }
            return candidateList;
        }
       
    }

    internal class FileStructure
    {
        public string Name { get; set; }
        public int? Size { get; set; }
        public int GetSize { get
            {
                if (Size == null)
                {
                    return Children.Sum(x => x.GetSize);
                }
                return Size.Value;
            } 
        }
        public FileStructure? Parent { get; set; }
        public List<FileStructure> Children { get; set; } = new List<FileStructure> { };
    }
}
