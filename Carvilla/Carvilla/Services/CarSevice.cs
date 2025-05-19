using Carvilla.Contexts;
using Carvilla.Models;

namespace Carvilla.Services;

public class CarSevice
{
    private readonly CarsDB _carsDb;

    public CarSevice()
    {
        _carsDb = new CarsDB();
    }

    #region CREATE

    public void CreateCar(Car car)
    {
        _carsDb.cars.Add(car);
        _carsDb.SaveChanges();
    }

    #endregion

    #region READ

    public List<Car> ReadCar()
    {
        return _carsDb.cars.ToList();
    }

    #endregion

    public Car GetCarById(int id)
    {
        Car foundedCar = _carsDb.cars.Find(id);
        if (foundedCar is not null)
        {
            
        return foundedCar;
        }
        else
        {
            throw new Exception("not found data");
        }
    }

    #region UPDATE

    public void UpdateCar(int id,Car updatedCar)
    {
        Car? selectedCar = _carsDb.cars.Find(id);

        if (selectedCar is not null)
        {
            selectedCar.Name = updatedCar.Name;
            selectedCar.Year = updatedCar.Year;
            selectedCar.Desc = updatedCar.Desc;
            selectedCar.HP = updatedCar.HP;
            selectedCar.Price = updatedCar.Price;
            selectedCar.ImgUrl = updatedCar.ImgUrl;
            selectedCar.Type = updatedCar.Type;
        }
        else
        {
            throw new Exception("Not found");
        }
    }
    #endregion

    #region DELETE
    public void DeleteCar(int id)
    {
        var foundedCar = _carsDb.cars.Find(id);
        if (foundedCar is not null) 
        {
            _carsDb.cars.Remove(foundedCar);
            _carsDb.SaveChanges();
        }
            
            
       
       
    }


    #endregion
}
