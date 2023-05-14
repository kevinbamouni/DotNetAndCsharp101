using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmArchitecture101.ViewModel
{
    public class VMforTest
    {
        public string TexttoShow { get; set; }

        public VMforTest()
        {
            TexttoShow = "CECI EST UN TEXT QUI VIENT DE LA VIEWMODEL VMFORTEST. PROP TEXTOSHOW";
        }
    }
}
