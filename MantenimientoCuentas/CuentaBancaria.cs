using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoCuentas
{
    /// <summary>
    /// Clase para cuentas bancarias. 
    /// </summary>
    internal class CuentaBancaria
    {
        /// <summary>
        /// Número de la cuenta bancaria
        /// </summary>
        public long NumeroCuenta { get; set; }

        /// <summary>
        /// Titular de la cuenta bancaria
        /// </summary>
        public string Titular { get; set; }

        /// <summary>
        /// Saldo actual de la cuenta
        /// </summary>
        public decimal Saldo { get; set; }

        /// <summary>
        /// Constructor nulo
        /// </summary>
        public CuentaBancaria() { }

        /// <summary>
        /// Constructor de la clase CuentaBancaria
        /// </summary>
        /// <param name="numeroCuenta">Número de cuenta</param>
        /// <param name="titular">Nombre del titular</param>
        /// <param name="saldo">Saldo de la cuenta</param>
        public CuentaBancaria(int numeroCuenta, string titular, decimal saldo)
        {
            this.NumeroCuenta = numeroCuenta;
            this.Titular = titular;
            this.Saldo = saldo;
        }

        /// <summary>
        /// Método para depositar dinero en la cuenta 
        /// </summary>
        /// <param name="cantidad">Candidad a depositar</param>
        public void Depositar(decimal cantidad)
        {
            if (cantidad > 0)
            {
                Saldo += cantidad;
                Console.WriteLine(String.Format("Depósito de {0} realizado con éxito. Nuevo saldo: {1}", cantidad.ToString("N2"), Saldo.ToString("N2")));
            }
            else
            {
                Console.WriteLine("La cantidad a depositar debe ser mayor que cero.");
            }
        }

        /// <summary>
        /// Método para retirar dinero de la cuenta
        /// </summary>
        /// <param name="cantidad">Candidad a retirar</param>
        public void Retirar(decimal cantidad)
        {
            if (cantidad > 0)
            {
                if (cantidad <= Saldo)
                {
                    Saldo -= cantidad;
                    Console.WriteLine(string.Format("Retiro de {0} realizado con éxito. Nuevo saldo: {1}", cantidad.ToString("N2"), Saldo.ToString("N2")));
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para realizar el retiro.");
                }
            }
            else
            {
                Console.WriteLine("La cantidad a retirar debe ser mayor que cero.");
            }
        }


        /// <summary>
        /// Método para obtener el saldo actual de la cuenta
        /// </summary>
        /// <returns>Saldo de la cuenta</returns>
        public decimal ObtenerSaldo()
        {
            return Saldo;
        }

        /// <summary>
        /// Imprime los datos de la cuenta
        /// </summary>
        public void MostarDatosCuenta()
        {
            Console.WriteLine(string.Format("Nro. Cuenta:  {0} -  Titular: {1} - Saldo: {2}", NumeroCuenta.ToString(), Titular, Saldo.ToString("N2")));
        }

    }
}
