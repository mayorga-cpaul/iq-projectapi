using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public class AssetDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountResidual { get; set; }
        public int Terms { get; set; }
        public string TipoDeDepreciation { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
}
