using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GIS.Models;

namespace GIS.Controllers
{
    [ApiController]
    [Route("spec/")]
    public class SpecTechnicalController : ControllerBase
    {
        /// <summary>
        /// Получение всех запущенных процессов с сортировкой по использованию ОЗУ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("process")]
        public Dictionary<string, long> GetListProcesses()
        {
            int count = 0;
            var processes = Process.GetProcesses();
            var processList = new Dictionary<string, long>();
            foreach (var p in processes)
            {
                p.Refresh();
                processList.Add($"{count++}. name: "+p.ProcessName, p.WorkingSet64/1024);
            }

            var processNewList = processList
                .OrderBy(p => p.Value)
                .ToDictionary(p => p.Key, v => v.Value);
            return processNewList;
        }


        /// <summary>
        /// Работа со строкой
        /// </summary>
        /// <param name="str">входная строка</param>
        /// <returns>Возвращает результат операций в модели</returns>
        [HttpPost]
        [Route("changingline")]
        public ReturnValue PostStringMethod(string str)
        {
            var strHash = StringLogic.Sha256HashString(str);
            var strCoup = StringLogic.StringReverse(str);
            var strDictionary = StringLogic.NumberSymbols(str);
            var model = new ReturnValue
            {
                HashString = strHash,
                ReverseString = strCoup,
                DictionaryString = strDictionary
            };
            return model;
        }

        
    }
}
