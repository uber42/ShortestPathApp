using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Routing.Interfaces
{
    interface ICachedControl
    {
        /// <summary>
        /// Кэш представления
        /// </summary>
        Bitmap Cache
        {
            get;
            set;
        }

        /// <summary>
        /// Закеширован ли контрол
        /// </summary>
        /// <returns></returns>
        bool IsCached();

        /// <summary>
        /// Создать кэш
        /// </summary>
        void MakeCache();

        /// <summary>
        /// Инвалидировать кэш изображение
        /// </summary>
        void InvalidateCache();
    }
}
