using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenimientoCuentas
{
    internal class Program
    {
        /// <summary>
        /// Método principal que inicia el programa
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //Se delcara lista de cuetnas y se inicializa
            List<CuentaBancaria> lstCuentas = new List<CuentaBancaria>();
            ConfigurarCuentas(ref lstCuentas);

            //Variables para menú
            string opcionIngresada = string.Empty;

            bool salir = false;

            Console.WriteLine("Bienvenido al sistema de manejo de cuentas.");
            Console.WriteLine("");
            

            while (salir == false)
            {
                try
                {
                    //Se imprimen las cuentas para poder darles mantenimiento
                    Console.WriteLine("");
                    foreach (CuentaBancaria cuenta in lstCuentas)
                    {
                        cuenta.MostarDatosCuenta();
                    }
                    Console.WriteLine("Seleccione una acción a realizar");
                    Console.WriteLine("1 = Buscar cuenta ");
                    Console.WriteLine("0 = Salir");
                    Console.WriteLine("");
                    //Opciones para búsquea de una cuenta 
                    opcionIngresada = Console.ReadLine();
                    if (VerificarOpicion(opcionIngresada))
                    {
                        switch (Convert.ToInt32(opcionIngresada))
                        {
                            case 1:
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese un número de cuenta");
                                opcionIngresada = Console.ReadLine();
                                if (VerificarOpicion(opcionIngresada))
                                {
                                    CuentaBancaria cuentaAOperar = BuscarCuenta(Convert.ToInt32(opcionIngresada), lstCuentas);
                                    if (cuentaAOperar != null)
                                    {
                                        cuentaAOperar.MostarDatosCuenta();
                                        OperarCuenta(cuentaAOperar);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encontró el número de cuenta.");
                                    }
                                }
                                break;
                            case 0:
                                salir = true;
                                break;
                            default:
                                Console.WriteLine("Opción no válida, por favor vuelva a ingresar la opción.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Ocurrió un problema en la ejecución del programa. {0}", ex.Message));
                }
            }
        }
        
        /// <summary>
        /// Valida que la opción ingresada sea un número válido.
        /// </summary>
        /// <param name="opcionIngresada"></param>
        /// <returns></returns>
        private static bool VerificarOpicion(string opcionIngresada)
        {
            bool nroValido = false;
            int opcionValida = 0;
            if (int.TryParse(opcionIngresada, out opcionValida))
            {
                nroValido = true;
            }
            else
            {
                Console.WriteLine("Debe ingresar un valor numérico");
            }
            return nroValido;
        }

        /// <summary>
        /// Método para el mantenimiento de cuentas bancarias. 
        /// </summary>
        /// <param name="cuentaAOperar"></param>
        /// <exception cref="Exception"></exception>
        private static void OperarCuenta(CuentaBancaria cuentaAOperar)
        {
            //Variables para menú
            string opcionIngresada = string.Empty;
            bool salir = false;
            while (salir == false)
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("Seleccione una acción a realizar");
                    Console.WriteLine("1 = Depositar ");
                    Console.WriteLine("2 = Retirar");
                    Console.WriteLine("3 = Verificar Saldo");
                    Console.WriteLine("0 = Salir");
                    Console.WriteLine("");
                    opcionIngresada = Console.ReadLine();

                    if (VerificarOpicion(opcionIngresada))
                    {
                        //Opciones para mantenimiento de cuenta
                        switch (Convert.ToInt32(opcionIngresada))
                        {
                            case 1:
                                Console.Write("Ingrese la cantidad a depositar: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal cantidadDeposito))
                                {
                                    cuentaAOperar.Depositar(cantidadDeposito);
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida.");
                                }
                                break;
                            case 2:
                                Console.Write("Ingrese la cantidad a retirar: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal cantidadRetiro))
                                {
                                    cuentaAOperar.Retirar(cantidadRetiro);
                                }
                                else
                                {
                                    Console.WriteLine("Cantidad inválida.");
                                }
                                break;
                            case 3:
                                Console.WriteLine(string.Format("Su saldo actual es: {0}", cuentaAOperar.ObtenerSaldo().ToString("N2")));
                                break;
                            case 0:
                                salir = true;
                                break;
                            default:
                                Console.WriteLine("Opción no válida, por favor vuelva a ingresar la opción.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Ocurrió un problema en la ejecución del programa. {0}", ex.Message), ex);
                }
            }
        }

        /// <summary>
        /// Método que inicializa la lista de cuentas bancarias.
        /// </summary>
        /// <param name="lstCuentas">Lista de cuentas a inicializar</param>
        private static void ConfigurarCuentas(ref List<CuentaBancaria> lstCuentas)
        {
            lstCuentas.Add(new CuentaBancaria(1, "Juan Santos Maldonado", Convert.ToDecimal(3000.00)));
            lstCuentas.Add(new CuentaBancaria(2, "Sindy Ramos Giménez", Convert.ToDecimal(700.23)));
            lstCuentas.Add(new CuentaBancaria(3, "Brandon Canux Julian", Convert.ToDecimal(500.50)));
            lstCuentas.Add(new CuentaBancaria(4, "Luis Garcia Sarmiento", Convert.ToDecimal(4000.00)));
            lstCuentas.Add(new CuentaBancaria(5, "Oscar Vásquez Castillo", Convert.ToDecimal(5345.12)));
            lstCuentas.Add(new CuentaBancaria(6, "José Hernánde Méndez", Convert.ToDecimal(1345.70)));

        }

        /// <summary>
        /// Busca una cuenta bancaria dentro de la lista existente.
        /// </summary>
        /// <param name="NroCuenta">Número de cuenta a buscar</param>
        /// <param name="lstCuentas">Listado de cuentas bancarias</param>
        /// <returns></returns>
        private static CuentaBancaria BuscarCuenta(int NroCuenta, List<CuentaBancaria> lstCuentas)
        {
            CuentaBancaria CuentaEncontrada = lstCuentas.Find(cuenta => cuenta.NumeroCuenta == NroCuenta);
            return CuentaEncontrada;
        }

    }
}
