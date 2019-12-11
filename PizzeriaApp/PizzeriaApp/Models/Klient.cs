using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaApp.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdUser { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(ErrorMessage = "Nazwisko nie może być dłuższe niż 20 znaków")]
        public string Nazwisko { get; set; }
        [MaxLength(ErrorMessage = "Adres nie może być dłuższy niż 150 znaków")]
        public string Adres { get; set; }
        [MaxLength(ErrorMessage = "Telefon nie może być dłuższy niż 12 znaków")]
        public string Telefon { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
