using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Laborare.Models
{
    public interface IIOBoard
    {
        int BoardNum { get; }
        string SerialNumber { get; }
        string ModelName { get; }

        bool s0 { get; set; }
        bool s1 { get; set; }
        bool s2 { get; set; }
        bool s3 { get; set; }
        bool s4 { get; set; }
        bool s5 { get; set; }
        bool s6 { get; set; }
        bool s7 { get; set; }
        bool s8 { get; set; }
        bool s9 { get; set; }
        bool s10 { get; set; }
        bool s11 { get; set; }
        bool s12 { get; set; }
        bool s13 { get; set; }
        bool s14 { get; set; }
        bool s15 { get; set; }

        bool sol1 { get; set; }
        bool sol2 { get; set; }
        bool sol3 { get; set; }
        bool sol4 { get; set; }
        bool sol5 { get; set; }
        bool sol6 { get; set; }
        bool sol7 { get; set; }
        bool sol8 { get; set; }
        bool sol9 { get; set; }
        bool sol10 { get; set; }
        bool sol11 { get; set; }
        bool sol12 { get; set; }
        bool sol13 { get; set; }
        bool sol14 { get; set; }
        bool sol15 { get; set; }
        bool sol16 { get; set; }

        byte InputSignal_Port0 { get; set; }
        byte InputSignal_Port1 { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
