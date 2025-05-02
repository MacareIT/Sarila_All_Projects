using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_MedicineExpiryAlert
{
    class Program
    {  
        static void Main(string[] args)
        {
            ServiceReference1.WebService_ExpirySoapClient objService = new ServiceReference1.WebService_ExpirySoapClient();
            //objService.Get_ExpiryMedicines_Cherpu();
            //objService.Get_ExpiryMedicines_Kanjany();
            //objService.Get_ExpiryMedicines_Kattoor();
            objService.Get_ExpiryMedicines_Valapad();
            //objService.Get_ExpiryMedicines_Vdply();
            //objService.Get_ExpiryMedicines_Wholesale();
        }
    }
}
