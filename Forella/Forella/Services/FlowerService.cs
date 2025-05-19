using Forella.Contexts;
using Forella.Exceptions;
using Forella.Models;

namespace Forella.Services;

public class FlowerService
{
    private readonly FlowersDBContext _dbcontext;
    public FlowerService()
    {
        _dbcontext = new FlowersDBContext();
    }


    #region CREATE

    public void AddFlower(Flower flower)
    {
        _dbcontext.Flowers.Add(flower);
        _dbcontext.SaveChanges();
    }

    #endregion

    #region READ
    public List<Flower> ReadFlower()
    {
        return _dbcontext.Flowers.ToList();
    }
    #endregion

    #region UPDATE

    public void Update(int id,Flower flower)
    {
        var foundedData = _dbcontext.Flowers.Find(id);
        foreach (var item in _dbcontext.Flowers)
        {
            if (item.Id == id)
            {
                item.Name = flower.Name;
                item.Price = flower.Price;
                item.ImgUrl = flower.ImgUrl;
            }
        }
    }

    #endregion

    #region DELETE
    public void DeleteFlower(int id)
    {
        
            var foundedData = _dbcontext.Flowers.Find(id);      
       
            _dbcontext.Flowers.Remove(foundedData);
            _dbcontext.SaveChanges();
      
        
    }
    #endregion
}
