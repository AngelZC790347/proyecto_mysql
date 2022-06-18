using controllers;
using models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Globalization;
using services;
using System.Text.Json;

namespace proyecto_final
{
    class Program
    {
        static string nombre, apellido;
        static uint dni;
        static List<ProductoPlatillos> pp;

        public static void Main()
        {
            byte op = 0;
            try
            {
                pp = ProductoPlatillosController.obtenerMenu();
                do
                {
                    Console.Clear();
                    System.Console.Write("\tMenu\n0 . Salir \n1 . Cliente\n2 . Admin\nop : ");
                    op = byte.Parse(Console.ReadLine());
                    if (op == 0)
                    {
                        break;
                    }
                    else
                    {
                        if (op == 1)
                        {
                            menuCliente();
                            break;
                        }
                        else
                        {
                            if (op == 2)
                            {
                                menuAdmin();
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine("Opcion no valida presione una tecla para continuar");
                            }
                        }
                    }
                } while (op != 0);
            }
            catch (System.Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }

        public static void menuAdmin()
        {
            byte op3 = 0;
            do
            {
                Console.Clear();
                System.Console.WriteLine("\tMenu de Administrador\n".ToUpper());
                System.Console.Write("0 . salirR\n1 .Total de pedidos recibidos \n2 . Porcentaje de pedidos entregados y su total en dinero acumulado\n3 .Porcentaje de pedidos cancelados y su total en dinero acumulado\n4 .Pedidos entregados según plato \n5 . Pedidos cancelados según plato\n\nOP-> ");
                op3 = byte.Parse(Console.ReadLine());
                if (op3 == 0)
                {
                    break;
                }
                else if (op3 == 1)
                {
                    System.Console.WriteLine("Total de Pedidos del dia: " + new DetallePedidosService().contarRegistros());
                }
                else if (op3 == 2)
                {

                    System.Console.WriteLine("\tPEEDIDOS ENTREGADOS\n");
                    float sum = 0;
                    var listaRes = obtenerMappingPorEstado(ESTADOS_REPARTO.ENTREGADO);
                    listaRes.All((v) => { sum += v.Value; return true; });
                    System.Console.WriteLine("Porcentaje de pedidos: " + listaRes.Count * 100 / new RepartoPedidosService().contarRegistros());
                    System.Console.WriteLine("Total de Dinero Acumulado: " + sum);
                }
                else if (op3 == 3)
                {
                    float sum = 0;
                    var listaRes = obtenerMappingPorEstado(ESTADOS_REPARTO.CANCELADO);
                    System.Console.WriteLine("\tPEEDIDOS CANCELADO\n");
                    System.Console.WriteLine("Porcentaje de pedidos: " + listaRes.Count * 100 / new RepartoPedidosService().contarRegistros());
                    System.Console.WriteLine("Total de Dinero Acumulado: " + sum);
                }
                else if (op3 == 4)
                {
                    var listaRes = obtenerMappingPorEstado(ESTADOS_REPARTO.ENTREGADO);
                    var pE = mappingDataProductosCantidad(listaRes);
                    foreach (var item in pE)
                    {
                        System.Console.WriteLine("Cantidad de Productos  Entregados por categoria");
                        System.Console.WriteLine($"{item.Key} : {item.Value}");
                    }
                    break;
                }
                else if (op3 == 5)
                {
                    var listaRes = obtenerMappingPorEstado(ESTADOS_REPARTO.CANCELADO);
                    var pc = mappingDataProductosCantidad(listaRes);
                    foreach (var item in pc)
                    {
                        System.Console.WriteLine("Cantidad de Productos  Cancelados por categoria");
                        System.Console.WriteLine($"{item.Key} : {item.Value}");
                    }
                }
                System.Console.WriteLine("Presiones un  tecla para conmtinuar");
                Console.ReadKey();
            } while (op3 != 0);
        }

        private static void menuClientePart2(ClienteController actualCliente)
        {
            byte op2;
            do
            {
                Console.Clear();
                System.Console.WriteLine(actualCliente.pedidosHandler.obtenerInfoDePedido());
                System.Console.WriteLine("0 SALIR");
                System.Console.WriteLine("1. Confirmar  Pedido");
                System.Console.WriteLine("2 Cancelar pedido");
                System.Console.Write("3 Ver estado del pedido\n4 Confirmar que pedido se entrego\n\nOP2-> ");
                op2 = byte.Parse(Console.ReadLine());
                Console.Clear();
                if (op2 == 0)
                {
                    Environment.Exit(0);
                }
                switch (op2)
                {
                    case 1:
                        System.Console.Write("DIRECCION DE ENVIO: ");
                        actualCliente.confirmarPedido(Console.ReadLine());
                        System.Console.WriteLine("Estado: " + (ESTADOS_REPARTO)actualCliente.solicitarEstadoDelPedido());
                        System.Console.WriteLine("Presiones un  tecla para conmtinuar");
                        Console.ReadKey();
                        // Se envia el pedido al repartidor
                        actualCliente.notificarEnvioDePedido();
                        System.Console.WriteLine("Estado: " + (ESTADOS_REPARTO)actualCliente.solicitarEstadoDelPedido());
                        System.Console.WriteLine("Presiones un  tecla para conmtinuar");
                        Console.ReadKey();
                        break;
                    case 2:
                        actualCliente.cancelarPedido();
                        System.Console.WriteLine("Pedido cancelao Gracias");
                        Environment.Exit(0);
                        break;
                    case 3:
                        System.Console.WriteLine("Estado: " + (ESTADOS_REPARTO)actualCliente.solicitarEstadoDelPedido());
                        Console.ReadKey();
                        break;
                    case 4:
                        // Confirmar llegada del pedido 
                        actualCliente.confirmarEntregaPedido();
                        System.Console.WriteLine("Gracias por su compra");
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (op2 != 0);
        }

        private static void menuCliente()
        {
            System.Console.Write("Nombre :");
            nombre = Console.ReadLine();
            System.Console.Write("Apellido :");
            apellido = Console.ReadLine();
            System.Console.Write("Dni :");
            dni = uint.Parse(Console.ReadLine());
            Console.Clear();
            ClienteController actualCliente = new ClienteController(dni, nombre, apellido);
            string menu = "";
            pp.ForEach((p) => menu += p.detallar());
            System.Console.WriteLine($"\tMenu de Cliente {nombre} {apellido}\n");
            ushort op = 0;
            do
            {
                System.Console.WriteLine("0 Terminar Listar");
                System.Console.WriteLine(menu);
                System.Console.Write("\nOp: ");
                op = ushort.Parse(Console.ReadLine());
                if (op == 0)
                {
                    menuClientePart2(actualCliente);
                    break;
                }
                System.Console.Write("Cantidad ");
                byte cantidad = byte.Parse(Console.ReadLine());
                actualCliente.agregarPedido(op, cantidad);
                Console.Clear();
                System.Console.WriteLine("PEDIDO\n" + actualCliente.pedidosHandler.obtenerInfoDePedido());
            } while (op != 0);
        }

        public static void Conectar()
        {
            Socket socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                socketCliente.Bind(miDireccion);
                socketCliente.Listen(10);
                Console.WriteLine("Esperando Clientes");
                Socket Escuchar = socketCliente.Accept();
                byte[] bytes;
                int contador = 1;
                while (true)
                {
                    string data = null;
                    bytes = new byte[1024];
                    int lbyte = Escuchar.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, lbyte);
                    switch (contador)
                    {
                        case 1:
                            nombre = data;
                            break;
                        case 2:
                            apellido = data;
                            break;
                        case 3:
                            ushort op = 0;
                            dni = uint.Parse(data);
                            ClienteController actualCliente = new ClienteController(dni, nombre, apellido);
                            string menu = actualCliente.solicitarMenu();
                            Escuchar.Send(Encoding.ASCII.GetBytes(menu));
                            do
                            {
                                data = null;
                                bytes = new byte[1024];
                                lbyte = Escuchar.Receive(bytes);
                                data += Encoding.ASCII.GetString(bytes, 0, lbyte);
                                op = ushort.Parse(data);
                                if (op == 0)
                                {
                                    Escuchar.Send(Encoding.ASCII.GetBytes(actualCliente.pedidosHandler.obtenerInfoDePedido()));
                                }
                            } while (op != 0);


                            break;
                        case 4:
                            break;
                    }
                    contador++;
                }
                socketCliente.Close();

            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.ToString());
            }
            Console.WriteLine("Presione cualquier tecla para terminar");
            Console.ReadLine();

        }

        private static Dictionary<ulong, float> obtenerMappingPorEstado(ESTADOS_REPARTO estadoReq)
        {
            var res = new Dictionary<ulong, float>();
            RepartoPedidosService r1 = new RepartoPedidosService();
            FacturaService f1 = new FacturaService();
            string result = r1.dispatchQuery($"select r1.id_pedido , f1.monto from {r1.table_name} as r1 inner join {f1.table_name} as f1 on f1.id_pedido = r1.id_pedido and r1.estado = {(byte)estadoReq}");
            var r = result.Split('\n').ToList();
            r.Remove(r[r.Count - 1]);
            r.ForEach((c) =>
            {
                var res2 = c.Split(' ').ToArray();
                res.Add(ulong.Parse(res2[0]), float.Parse(res2[1]));
            });
            return res;
        }

        private static Dictionary<string, int> mappingDataProductosCantidad(Dictionary<ulong, float> listaRes)
        {
            var res = new Dictionary<string, int>();
            Pedido[] ap = new Pedido[listaRes.Count];
            string[] dp = new String[listaRes.Count];
            var pS = new DetallePedidosService();
            pp.ForEach((p) => res.Add(p.nombre, 0));
            foreach (var item in listaRes)
            {
                string msg = "";
                var json = pS.obtenerEntidadPorId(item.Key).Split(' ');
                for (int i = 1; i < json.Count(); i++)
                {
                    msg += json[i];
                }
                var pedidos = JsonSerializer.Deserialize<List<Pedido>>(msg);
                pedidos.ForEach((v) => res[v.producto.nombre] += v.cantidad);
            }
            return res;
        }
    }
}