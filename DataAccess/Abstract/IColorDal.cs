using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        /*
        Color GetColorById(int colorId);
        List<Color> GetAll();
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
        */
    }
}
