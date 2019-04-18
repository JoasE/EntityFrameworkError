using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperError.Shared.Config;
using AutoMapperError.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperError.Shared
{
    public static class Replicator
    {
        public static async Task Replicate()
        {
            // Arrange
            Mapper.Initialize(cfg => cfg.AddProfile<Mappings>());
            var context = new AutoMapperErrorContext();

            var user = new User();
            context.Users.Add(user);
            await context.SaveChangesAsync();


            var course = new Course();

            var lab = new Lab();
            course.Labs.Add(lab);

            var assignment = new Assignment();
            lab.Assignments.Add(assignment);

            var work = new UserAssignment()
            {
                UserId = user.Id
            };
            assignment.UserAssignments.Add(work);

            context.Courses.Add(course);
            await context.SaveChangesAsync();

            context.Dispose();

            context = new AutoMapperErrorContext();

            var userId = user.Id;

            // Manual query
            var manualQuery = context.Courses.Select(
                dtoCourse => new Course.View
                {
                    Id = dtoCourse.Id,
                    Labs = dtoCourse.Labs.Select(
                        dtoLab => new Lab.View
                        {
                            Assignments = dtoLab.Assignments
                                .Select(
                                    dtoAssignment => new GeneratedType
                                    {
                                        __CurrentWork =
                                            dtoAssignment.UserAssignments.FirstOrDefault(x => x.UserId == userId),
                                        Id = dtoAssignment.Id,
                                        Lab = dtoAssignment.Lab,
                                        LabId = dtoAssignment.LabId,
                                        Name = dtoAssignment.Name
                                    })
                                .Select(
                                    dtoLet => new Assignment.View
                                    {
                                        CurrentWork = (dtoLet.__CurrentWork == null)
                                            ? null
                                            : new UserAssignment.View
                                            {
                                                AssignmentId = dtoLet.__CurrentWork.AssignmentId,
                                                StartedAt = dtoLet.__CurrentWork.StartedAt,
                                                UserId = dtoLet.__CurrentWork.UserId
                                            },
                                        Id = dtoLet.Id,
                                        Lab = dtoLet.Lab,
                                        LabId = dtoLet.LabId,
                                        Name = dtoLet.Name
                                    })
                                .ToList(),
                            CourseId = dtoLab.CourseId,
                            Id = dtoLab.Id,
                            Name = dtoLab.Name
                        }).ToList(),
                    Name = dtoCourse.Name,
                    Order = dtoCourse.Order
                });
            var manualExpression = manualQuery.Expression;

            var manualCourses = await manualQuery.ToListAsync();

            // Automapper query
            var coursesQuery = context.Courses.ProjectTo<Course.View>(new {userId = user.Id});
            var expression = coursesQuery.Expression;

            var courses = await coursesQuery.ToListAsync();
        }
    }

    public class GeneratedType
    {
        public UserAssignment __CurrentWork { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid LabId { get; set; }
        public Lab Lab { get; set; }
    }
}
