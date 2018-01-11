using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СSharp_example
{
    public abstract class MenuComponent
    {
        // Группа "комбинационных" методов - то есть метдов для добавления, удаления и получения MenuComponent
        #region 
        public virtual void Add(MenuComponent menuComponent)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(MenuComponent menuComponent)
        {
            throw new NotImplementedException();
        }
        public virtual MenuComponent GetChild(int i)
        {
            throw new NotImplementedException();
        }
        // Добавлен новый метод
        public virtual ArrayList GetMenu()
        {
            throw new NotImplementedException();
        }
        // Добавлен новый метод
        public virtual int Count()
        {
            throw new NotImplementedException();
        }
        #endregion

        // Группа "методов операций", используемых MenuItem. Некоторые из этих методов также могут использоваться в Menu. 
        #region 
        public virtual String GetName()
        {
            throw new NotImplementedException();
        }
        public virtual String GetDescription()
        {
            throw new NotImplementedException();
        }
        public virtual double GetPrice()
        {
            throw new NotImplementedException();
        }
        public virtual bool IsVegetarian()
        {
            return false;
        }
        #endregion

        // Метод Print() реализуется как в Menu, так и в MenuItem
        public virtual void Print()
        {
            throw new NotImplementedException();
        }
        //// Чтобы реализовать итератор для комбинации, мы добавляем метод createIterator(). 
        //public abstract IEnumerator CreateIterator();
    }
}
