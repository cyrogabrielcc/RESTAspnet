using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAspnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorContoller : ControllerBase
    {
       
       private readonly ILogger<CalculatorContoller> _logger;

        public CalculatorContoller(ILogger<CalculatorContoller> logger)
        {
            _logger = logger;
        }

        // implemetando a adicao
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
           if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
               var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString("F2"));
            }
            return BadRequest("Invalid Input");
        }
        // implemetnando a subtracao
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sub.ToString("F2"));
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            }
            return BadRequest("invalid input");
        }
        [HttpGet("mult/{firstNumber}/{secondNumber}")]

        public IActionResult GetMult(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) && !IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            }
            return BadRequest("invalidInput");
        }

        // vendo se é um num
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, 
                                            System.Globalization.NumberStyles.Any, 
                                            System.Globalization.NumberFormatInfo.InvariantInfo, 
                                            out number);
            return isNumber;
        }

        // convertendo pra decimal
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber,out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
