using Application.Models.DTOs;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Extensions
{
    public static class ConvertExtensions
    {
        public static SalaryRequestDTO ConvertToSalary(DataTypeEnum dataType,string data)
        {
            //for example I handled two type of dataType
            var salary = new SalaryRequestDTO();
            //try
            //{
                if (dataType == DataTypeEnum.Json)
                {
                    salary = JsonConvert.DeserializeObject<SalaryRequestDTO>(data);
                }
                else if (dataType == DataTypeEnum.Custom)
                {
                    salary = GetCustomData(data);
                }

            return salary;
        }

        private static SalaryRequestDTO GetCustomData(string data)
        {
            string output = "";

            var seperateColumnAndFields = data.Split('\n');
            if (seperateColumnAndFields.Length != 2)
                throw new Exception("data not contains \n");

            var columns = seperateColumnAndFields[0].Split('/');
            var fields = seperateColumnAndFields[1].Split('/');

            if(columns.Length!=fields.Length)
                throw new Exception("data input is invalid!");

            for (int i= 0; i < columns.Length; i++){
                output += $"\'{columns[i]}\':\'{fields[i]}\',";
            }

            output ="{"+ output.Trim(',')+"}";
            var salary= JsonConvert.DeserializeObject<SalaryRequestDTO>(output);
            return salary;
        }


    }


}
