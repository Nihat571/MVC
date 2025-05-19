using MVC_New_project.Contexts;
using MVC_New_project.Models;
using System.Drawing;

namespace MVC_New_project.Services;

public class ProgramService
{
    private readonly AppDBContext _programDB;

    public ProgramService()
    {
        _programDB = new AppDBContext();
    }

    #region CREATE

    public void AddProgram(GymProgram gymProgram)
    {
        _programDB.GymPrograms.Add(gymProgram);
        _programDB.SaveChanges();
    }


    #endregion

    #region Read

    public List<GymProgram> ReadProgram()
    {
        return _programDB.GymPrograms.ToList();
    }

    public GymProgram ReadProgramById(int id) 
    {
        var clickedProgram = _programDB.GymPrograms.Find(id);
        if (clickedProgram is not null)
        {
            return clickedProgram;
        }
        else
        {
            throw new Exception("data not found");
        }
    }

    #endregion

    #region UPDATE

    public void UpdateProgram(int id,GymProgram updatedProgram)
    {
        var clickedProgram = _programDB.GymPrograms.Find(id);
        if (clickedProgram is not null) 
        {
          clickedProgram.Name = updatedProgram.Name;
          clickedProgram.Description = updatedProgram.Description;
          clickedProgram.ImgUrl = updatedProgram.ImgUrl;
            _programDB.SaveChanges();
        }
        else
        {
            throw new Exception("data not found");
        }
    }


    #endregion

    #region DELETE

    public void DeleteProgram(int id) 
    {
        var clickedProgram = _programDB.GymPrograms.Find(id);
        if (clickedProgram is not null)
        {
           _programDB.GymPrograms.Remove(clickedProgram);
            _programDB.SaveChanges();
        }
        else
        {
            throw new Exception("data not found");
        }

    }


    #endregion
}
