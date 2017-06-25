using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class DietPlan
    {
        private List<Dish> bestItems;

        private double maxP;

        private double bestF;

        private double bestC;

        private readonly NutritionLimits _nutritionLimits;

        public DietPlan(double _maxP)
        {
            maxP = _maxP;
            _nutritionLimits = new NutritionLimits();
            bestItems = new List<Dish>();
        }

        //создание всех наборов перестановок значений
        public void MakeAllSets(List<Dish> items)
        {
            if (items.Count > 0)
                CheckSet(items);

            for (int i = 0; i < items.Count; i++)
            {
                List<Dish> newSet = new List<Dish>(items);

                newSet.RemoveAt(i);

                MakeAllSets(newSet);
            }

        }

        //проверка, является ли данный набор лучшим решением задачи
        private void CheckSet(List<Dish> items)
        {
            if (!bestItems.Any())
            {
                if (CalcProt(items) <= maxP && CalcProt(items)> _nutritionLimits.MinProtein)
                {
                    bestItems = items;
                    bestC = CalcC(items);
                    bestF = CalcF(items);
                }
            }
            else
            {
                var p = CalcProt(items);
                var c = CalcC(items);
                var f = CalcF(items);
                if ((p  <= maxP && p > _nutritionLimits.MinProtein) && (c < bestC && c > _nutritionLimits.MinCarbohydrates && c < _nutritionLimits.MaxCarbohydrates) &&
                    (f < bestF && f > _nutritionLimits.MinFats && f < _nutritionLimits.MaxFats))
                {
                    bestItems = items;
                    bestC = CalcC(items);
                    bestF = CalcF(items);
                }
            }
        }

        //вычисляет общий вес набора предметов
        private double CalcProt(List<Dish> items)
        {
            double sumW = 0;

            foreach (Dish i in items)
            {
                sumW += i.ProteinsPer100Grams;
            }

            return sumW;
        }

        //вычисляет общую стоимость набора предметов
        private double CalcC(List<Dish> items)
        {
            double sumPrice = 0;

            foreach (Dish i in items)
            {
                sumPrice += i.CarbohydratesPer100Grams;
            }

            return sumPrice;
        }
        private double CalcF(List<Dish> items)
        {
            double sumPrice = 0;

            foreach (Dish i in items)
            {
                sumPrice += i.FatsPer100Grams;
            }

            return sumPrice;
        }

        //возвращает решение задачи (набор предметов)
        public List<Dish> GetBestSet()
        {
            return bestItems;
        }
    }
}
