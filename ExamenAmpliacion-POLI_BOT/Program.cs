using System;
using CoreAPI;
using Entities_POJO;
using Exceptions;

namespace ExamenAmpliacion_POLI_BOT
{

    class Program
    {

        public static Usuario sesion;

        static void Main(string[] args)
        {

            DoIt();

        }

        public static void DoIt()
        {
            try
            {
                var secionIniciada = false;

                while (secionIniciada == false)
                {
                    secionIniciada = IniciarSesion();
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Bienvenido " + sesion.Nombre + " ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("A que idioma deseas traducir el dia de hoy:");
                Console.WriteLine(" ");
                var idioma = new Idioma { Nombre = Console.ReadLine().ToLower() };

                IdiomaManager img = new IdiomaManager();
                var nombreIdioma = img.RetrieveByName(idioma);
                var frase = new Frase();

                if (nombreIdioma == null)
                {
                    img.Create(idioma);
                    nombreIdioma = img.RetrieveByName(idioma);
                }

                if (idioma.Nombre.Equals(nombreIdioma.Nombre, StringComparison.CurrentCultureIgnoreCase))
                {
                    FraseManager fmg = new FraseManager();
                    Console.WriteLine("Ingrese la frase que desea traducir, en espa\u00f1ol:");

                    string palabra = Console.ReadLine();
                    FraseTraducidaManager ftmg = new FraseTraducidaManager();
                    frase = new Frase { Palabra = palabra };
                    FraseTraducida fraseTraducida = new FraseTraducida
                    {
                        Palabra = frase.Palabra,
                        NombreIdioma = idioma.Nombre
                    };

                    if (palabra.Contains(" ") != true)
                    {
                        if (fmg.RetrieveByName(frase) == null)
                        {
                            fmg.Create(frase);
                            if (ftmg.RetrieveByName(fraseTraducida) == null)
                            {
                                var listaPalabras = palabra.Split(' ');
                                var traducida = "";
                                int popularidad = 0;

                                foreach (string palActual in listaPalabras)
                                {
                                    frase = new Frase { Palabra = palActual };
                                    if (fmg.RetrieveByName(frase) == null)
                                    {
                                        fmg.Create(frase);
                                    }

                                    fraseTraducida = new FraseTraducida
                                    {
                                        Palabra = frase.Palabra,
                                        NombreIdioma = idioma.Nombre
                                    };

                                    if (ftmg.RetrieveByName(fraseTraducida) == null)
                                    {
                                        fraseTraducida = SolicitarTraduccion(frase, idioma, fraseTraducida);
                                        traducida += fraseTraducida.PalabraTraducida + " ";
                                    }

                                    popularidad += fmg.RetrieveByName(frase).Popularidad;
                                }

                                frase = new Frase { Palabra = palabra, Popularidad = popularidad };
                                fraseTraducida = new FraseTraducida
                                {
                                    Palabra = frase.Palabra,
                                    PalabraTraducida = traducida,
                                    NombreIdioma = idioma.Nombre
                                };

                                ftmg.Create(fraseTraducida);
                            }
                        }
                        else
                        {
                            Imprimir(fraseTraducida);
                        }
                    }
                    else
                    {
                        frase = new Frase { Palabra = palabra };

                        if (fmg.RetrieveByName(frase) == null)
                        {
                            fmg.Create(frase);
                        }

                        if (ftmg.RetrieveByName(fraseTraducida) == null)
                        {
                            fraseTraducida = SolicitarTraduccion(frase, idioma, fraseTraducida);
                        }
                        Imprimir(fraseTraducida);
                    }



                    Traduccion registro = new Traduccion
                    {
                        Usuario = sesion.Nombre,
                        Idioma = idioma.Nombre,
                        FraseEspannol = fraseTraducida.Palabra,
                        FraseIdioma = fraseTraducida.PalabraTraducida,
                        Popularidad = frase.Popularidad
                    };
                    TraduccionManager tmg = new TraduccionManager();
                    tmg.Create(registro);

                }
            }

            catch (BussinessException bex)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("ERROR: \n");
                Console.WriteLine(bex.AppMessage.Message);
                Console.WriteLine("***************************");
            }
            finally
            {
                Console.WriteLine("Continue? Y/N");
                var moreActions = Console.ReadLine();

                if (moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                    DoIt();
            }

            Console.ReadLine();
        }

        public static FraseTraducida SolicitarTraduccion(Frase frase, Idioma idioma, FraseTraducida fraseTraducida)
        {
            FraseTraducidaManager ftmg = new FraseTraducidaManager();
            Console.WriteLine("No poseo la traduccion de la palabra " + frase.Palabra +
                              " en el idioma " + idioma.Nombre + ", por favor ingrese la traduccion:");
            fraseTraducida.PalabraTraducida = Console.ReadLine();
            ftmg.Create(fraseTraducida);
            return fraseTraducida;
        }

        public static void Imprimir(FraseTraducida fraseTraducida)
        {
            FraseTraducidaManager ftmg = new FraseTraducidaManager();
            fraseTraducida = ftmg.RetrieveByName(fraseTraducida);
            Console.WriteLine("La palabra " + fraseTraducida.Palabra + " traducida al " +
                              fraseTraducida.NombreIdioma + " es: " + fraseTraducida.PalabraTraducida);
        }

        public static bool IniciarSesion()
        {
            UsuarioManager umg = new UsuarioManager();
            var usuario = new Usuario();
            sesion = new Usuario();
            Console.WriteLine("Ingrese su nombre:");
            sesion.Nombre = Console.ReadLine();
            usuario = umg.RetrieveByName(sesion);
            if (usuario != null)
            {
                Console.WriteLine("Ingrese la contrase\u00f1a:");
                sesion.Contrasenna = Console.ReadLine();
                if (usuario.Contrasenna.Equals(sesion.Contrasenna))
                {
                    Console.WriteLine("Sesion iniciada");
                    sesion = usuario;
                    return true;
                }
                else
                {
                    Console.WriteLine("Contrase\u00f1a incorecta......");
                    Console.WriteLine("Intente de nuevo");
                }
            }
            else
            {
                Console.WriteLine("Su usuario no se encuentra registrado. Desea registrarse?");
                Console.WriteLine("Y/N");
                var registrar = Console.ReadLine();
                if (registrar.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Ingrese una contrase\u00f1a, para el usuario " + sesion.Nombre + ":");
                    sesion.Contrasenna = Console.ReadLine();
                    umg.Create(sesion);
                    return true;
                }
            }

            return false;
        }
    }
}
