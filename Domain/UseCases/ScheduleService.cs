using Domain.Logic;
using Domain.IRepositories;
using Domain.Models;

namespace Domain.UseCases;
public class ScheduleService
{
    private IScheduleRepository _db;

    public ScheduleService(IScheduleRepository db)
    {
        _db = db;
    }

    public async Task<Result<Schedule>> GetSchedule(int id)
    {
        try
        {
            var success = await _db.Get(id);

            if (success is null)
            {
                return Result.Fail<Schedule>("Schedule doesn't exist.");
            }

            return Result.Ok<Schedule>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Schedule>();
        }
    }

    public async Task<Result<Schedule>> DeleteSchedule(int id)
    {
        try
        {
            var success = await _db.Delete(id);

            return Result.Ok<Schedule>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Schedule>();
        }
    }

    public async Task<Result<Schedule>> UpdateSchedule(Schedule schedule)
    {
        try
        {
            var success = await _db.Update(schedule);

            return Result.Ok<Schedule>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Schedule>();
        }
    }

    public async Task<Result<Schedule>> CreateSchedule(Schedule schedule)
    {
        try
        {
            var item = await _db.Get(schedule.Id);

            if (item is not null)
            {
                return Result.Fail<Schedule>("Schedule already exists.");
            }

            var success = await _db.Create(schedule);

            return Result.Ok<Schedule>(success);
        }
        catch (Exception)
        {
            return Result.Exception<Schedule>();
        }
    }

    public async Task<Result<List<Schedule>>> GetAllSchedules()
    {
        try
        {
            var success = await _db.GetAll();

            return Result.Ok<List<Schedule>>(success);
        }
        catch (Exception)
        {
            return Result.Exception<List<Schedule>>();
        }
    }

}
