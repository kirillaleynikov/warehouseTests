using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warehousenet2
{
    /// <summary>
    /// Сущность товара
    /// </summary>
    public class Tovar
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public decimal Razmer { get; set; }
        /// <summary>
        /// Материал
        /// </summary>
        public material Material { get; set; }
        /// <summary>
        /// Кол-во на складе
        /// </summary>
        public decimal kolvo { get; set; }
        /// <summary>
        /// Минимальный предел кол-ва
        /// </summary>
        public decimal minpr { get; set; }
        /// <summary>
        /// Цена (без НДС)
        /// </summary>
        public decimal price { get; set; }
    }
}
