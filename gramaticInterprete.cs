
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF              =  0, // (EOF)
        SYMBOL_ERROR            =  1, // (Error)
        SYMBOL_COMMENT          =  2, // Comment
        SYMBOL_NEWLINE          =  3, // NewLine
        SYMBOL_WHITESPACE       =  4, // Whitespace
        SYMBOL_DIVDIV           =  5, // '//'
        SYMBOL_MINUS            =  6, // '-'
        SYMBOL_TIMES            =  7, // '*'
        SYMBOL_DIV              =  8, // '/'
        SYMBOL__CADENA          =  9, // '_cadena'
        SYMBOL__CARACTER        = 10, // '_caracter'
        SYMBOL__ENTERO          = 11, // '_entero'
        SYMBOL__REAL            = 12, // '_real'
        SYMBOL_PLUS             = 13, // '+'
        SYMBOL_ABREPAR          = 14, // abrepar
        SYMBOL_CADENA           = 15, // cadena
        SYMBOL_CARACTER         = 16, // caracter
        SYMBOL_CIERRA           = 17, // cierra
        SYMBOL_CIERRAPAR        = 18, // cierrapar
        SYMBOL_COMA             = 19, // coma
        SYMBOL_ENTERO           = 20, // entero
        SYMBOL_FIN              = 21, // fin
        SYMBOL_IDENTIFICADOR    = 22, // Identificador
        SYMBOL_IGUAL            = 23, // igual
        SYMBOL_IMPRIMIR         = 24, // imprimir
        SYMBOL_INICIO           = 25, // inicio
        SYMBOL_REAL             = 26, // real
        SYMBOL_SOFTWARE         = 27, // software
        SYMBOL_ASIGNAR          = 28, // <Asignar>
        SYMBOL_DECLARACION      = 29, // <Declaracion>
        SYMBOL_DECLARACIONES    = 30, // <Declaraciones>
        SYMBOL_EXPRESION        = 31, // <Expresion>
        SYMBOL_FACTOR           = 32, // <Factor>
        SYMBOL_IDENTIFICADORES  = 33, // <Identificadores>
        SYMBOL_IMPRIMIR2        = 34, // <Imprimir>
        SYMBOL_PROGRAMA         = 35, // <Programa>
        SYMBOL_SENTENCIA        = 36, // <Sentencia>
        SYMBOL_SENTENCIAS       = 37, // <Sentencias>
        SYMBOL_TERMINO          = 38, // <Termino>
        SYMBOL_TIPOS            = 39, // <Tipos>
        SYMBOL_VALLITERALES     = 40, // <Val Literales>
        SYMBOL_VALNUMERICOS     = 41, // <Val Numericos>
        SYMBOL_VALORESLITERALES = 42  // <Valores Literales>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAMA_SOFTWARE__CADENA_INICIO_FIN           =  0, // <Programa> ::= software '_cadena' <Declaraciones> inicio <Sentencias> fin
        RULE_DECLARACIONES                                  =  1, // <Declaraciones> ::= <Declaracion>
        RULE_DECLARACIONES2                                 =  2, // <Declaraciones> ::= <Declaraciones> <Declaracion>
        RULE_DECLARACION                                    =  3, // <Declaracion> ::= <Tipos> <Identificadores>
        RULE_IDENTIFICADORES_IDENTIFICADOR                  =  4, // <Identificadores> ::= Identificador
        RULE_IDENTIFICADORES_COMA_IDENTIFICADOR             =  5, // <Identificadores> ::= <Identificadores> coma Identificador
        RULE_TIPOS_ENTERO                                   =  6, // <Tipos> ::= entero
        RULE_TIPOS_REAL                                     =  7, // <Tipos> ::= real
        RULE_TIPOS_CADENA                                   =  8, // <Tipos> ::= cadena
        RULE_TIPOS_CARACTER                                 =  9, // <Tipos> ::= caracter
        RULE_SENTENCIAS                                     = 10, // <Sentencias> ::= <Sentencia>
        RULE_SENTENCIAS2                                    = 11, // <Sentencias> ::= <Sentencias> <Sentencia>
        RULE_SENTENCIA                                      = 12, // <Sentencia> ::= <Asignar>
        RULE_SENTENCIA2                                     = 13, // <Sentencia> ::= <Imprimir>
        RULE_ASIGNAR_IDENTIFICADOR_IGUAL                    = 14, // <Asignar> ::= Identificador igual <Val Literales>
        RULE_ASIGNAR_IDENTIFICADOR_IGUAL2                   = 15, // <Asignar> ::= Identificador igual <Expresion>
        RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRAPAR            = 16, // <Imprimir> ::= imprimir abrepar cierrapar
        RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRAPAR2           = 17, // <Imprimir> ::= imprimir abrepar <Valores Literales> cierrapar
        RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRA               = 18, // <Imprimir> ::= imprimir abrepar <Val Numericos> cierra
        RULE_IMPRIMIR_IMPRIMIR_ABREPAR_IDENTIFICADOR_CIERRA = 19, // <Imprimir> ::= imprimir abrepar Identificador cierra
        RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRAPAR3           = 20, // <Imprimir> ::= imprimir abrepar <Expresion> cierrapar
        RULE_VALORESLITERALES                               = 21, // <Valores Literales> ::= <Val Literales>
        RULE_VALORESLITERALES_PLUS                          = 22, // <Valores Literales> ::= <Valores Literales> '+' <Val Literales>
        RULE_VALORESLITERALES_PLUS_IDENTIFICADOR            = 23, // <Valores Literales> ::= <Valores Literales> '+' Identificador
        RULE_VALLITERALES__CARACTER                         = 24, // <Val Literales> ::= '_caracter'
        RULE_VALLITERALES__CADENA                           = 25, // <Val Literales> ::= '_cadena'
        RULE_VALNUMERICOS__ENTERO                           = 26, // <Val Numericos> ::= '_entero'
        RULE_VALNUMERICOS__REAL                             = 27, // <Val Numericos> ::= '_real'
        RULE_EXPRESION_PLUS                                 = 28, // <Expresion> ::= <Expresion> '+' <Termino>
        RULE_EXPRESION_MINUS                                = 29, // <Expresion> ::= <Expresion> '-' <Termino>
        RULE_EXPRESION                                      = 30, // <Expresion> ::= <Termino>
        RULE_TERMINO_TIMES                                  = 31, // <Termino> ::= <Termino> '*' <Factor>
        RULE_TERMINO_DIV                                    = 32, // <Termino> ::= <Termino> '/' <Factor>
        RULE_TERMINO                                        = 33, // <Termino> ::= <Factor>
        RULE_FACTOR_ABREPAR_CIERRAPAR                       = 34, // <Factor> ::= abrepar <Expresion> cierrapar
        RULE_FACTOR                                         = 35, // <Factor> ::= <Val Numericos>
        RULE_FACTOR_IDENTIFICADOR                           = 36  // <Factor> ::= Identificador
    };

    public class MyParser
    {
        private LALRParser parser;


        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //Comment
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVDIV :
                //'//'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL__CADENA :
                //'_cadena'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL__CARACTER :
                //'_caracter'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL__ENTERO :
                //'_entero'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL__REAL :
                //'_real'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_ABREPAR :
                //abrepar
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_CADENA :
                //cadena
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_CARACTER :
                //caracter
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_CIERRA :
                //cierra
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_CIERRAPAR :
                //cierrapar
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_COMA :
                //coma
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_ENTERO :
                //entero
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_FIN :
                //fin
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_IDENTIFICADOR :
                //Identificador
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_IGUAL :
                //igual
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_IMPRIMIR :
                //imprimir
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_INICIO :
                //inicio
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_REAL :
                //real
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_SOFTWARE :
                //software
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_ASIGNAR :
                //<Asignar>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARACION :
                //<Declaracion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARACIONES :
                //<Declaraciones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESION :
                //<Expresion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFICADORES :
                //<Identificadores>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMPRIMIR2 :
                //<Imprimir>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAMA :
                //<Programa>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIA :
                //<Sentencia>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAS :
                //<Sentencias>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERMINO :
                //<Termino>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIPOS :
                //<Tipos>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALLITERALES :
                //<Val Literales>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALNUMERICOS :
                //<Val Numericos>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALORESLITERALES :
                //<Valores Literales>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAMA_SOFTWARE__CADENA_INICIO_FIN :
                    //<Programa> ::= software '_cadena' <Declaraciones> inicio <Sentencias> fin
                    //todo: Create a new object using the stored user objects.
                    return token.Tokens[2].UserObject;

                case (int)RuleConstants.RULE_DECLARACIONES :
                //<Declaraciones> ::= <Declaracion>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_DECLARACIONES2 :
                //<Declaraciones> ::= <Declaraciones> <Declaracion>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_DECLARACION :
                //<Declaracion> ::= <Tipos> <Identificadores>
                //todo: Create a new object using the stored user objects.
                ArrayList aux3 = (ArrayList)token.Tokens[1].UserObject;
                aux3.Add(token.Tokens[0].UserObject);
                simbolo dato;
                    bool encontrado = false;
                    for (int i = 0, nuevo_indice = -1; i < (aux3.Count - 1); i++ ){
                        dato.id = Convert.ToString(aux3[i]);
                        dato.tipo = Convert.ToString(aux3[aux3.Count - 1]);
                        for (int j = 0; j < TablaSimbolo.Count; j++)
                        {
                            if (TablaSimbolo[j].id == dato.id) encontrado = true;
                            if (TablaSimbolo[j].tipo == dato.tipo) nuevo_indice = TablaSimbolo[j].indice;
                        }
                        if (!encontrado)
                        {
                            dato.indice = ++nuevo_indice;
                            TablaSimbolo.Add(dato);
                        }
                        else errores = "Error: identificador " + dato.id + " duplicado";
                    }
                    return aux3;
                case (int)RuleConstants.RULE_IDENTIFICADORES_IDENTIFICADOR :
                //<Identificadores> ::= Identificador
                //todo: Create a new object using the stored user objects.
                ArrayList aux1 = new ArrayList();
                aux1.Add(token.Tokens[0].UserObject);
                return aux1;

                case (int)RuleConstants.RULE_IDENTIFICADORES_COMA_IDENTIFICADOR :
                //<Identificadores> ::= <Identificadores> coma Identificador
                //todo: Create a new object using the stored user objects.
                ArrayList aux2 = (ArrayList)token.Tokens[0].UserObject;
                aux2.Add(token.Tokens[2].UserObject);
                return aux2;

                case (int)RuleConstants.RULE_TIPOS_ENTERO :
                //<Tipos> ::= entero
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_TIPOS_REAL :
                //<Tipos> ::= real
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_TIPOS_CADENA :
                //<Tipos> ::= cadena
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_TIPOS_CARACTER :
                //<Tipos> ::= caracter
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_SENTENCIAS :
                //<Sentencias> ::= <Sentencia>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_SENTENCIAS2 :
                //<Sentencias> ::= <Sentencias> <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA :
                //<Sentencia> ::= <Asignar>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_SENTENCIA2 :
                //<Sentencia> ::= <Imprimir>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_ASIGNAR_IDENTIFICADOR_IGUAL :
                //<Asignar> ::= Identificador igual <Val Literales>
                //todo: Create a new object using the stored user objects.
                string tipo = "";
                int indice = 0;
                bool encontrado2 = false;
                    for (int i = 0; i < TablaSimbolo.Count; i++)
                    {
                        if(TablaSimbolo[i].id == Convert.ToString(token.Tokens[0].UserObject)){
                            encontrado2 = true;
                            tipo = TablaSimbolo[i].tipo;
                            indice = TablaSimbolo[i].indice;
                        }
                    }
                    if (encontrado2)
                    {
                        if (tipo == "cadena")
                        {
                            cadena[indice] = Convert.ToString(token.Tokens[2].UserObject).Trim('"');
                        }
                        else if(tipo == "caracter")
                        {
                            String band = Convert.ToString(token.Tokens[2].UserObject);
                            caracter[indice] = band.ToCharArray()[1];
                        }
                        else
                        {
                            errores = "Error de tipo: " + Convert.ToString(token.Tokens[0].UserObject) + " No es tipo cadena o caracter";
                        }
                    }
                    else
                    {
                        errores = "Error: " + Convert.ToString(token.Tokens[0].UserObject) + " No esta definida";
                    }
                    return null;

                case (int)RuleConstants.RULE_ASIGNAR_IDENTIFICADOR_IGUAL2 :
                    //<Asignar> ::= Identificador igual <Expresion>
                    //todo: Create a new object using the stored user objects.
                    string tipo1 = "";
                    int indice1 = 0;
                    bool encontrado3 = false;
                    for (int i = 0; i < TablaSimbolo.Count; i++)
                    {
                        if (TablaSimbolo[i].id == Convert.ToString(token.Tokens[0].UserObject)){
                            encontrado3 = true;
                            tipo1 = TablaSimbolo[i].tipo;
                            indice1 = TablaSimbolo[i].indice;
                        }
                    }
                    if (encontrado3)
                    {
                        if (tipo1 == "entero")
                        {
                            entero[indice1] = Convert.ToInt32(token.Tokens[2].UserObject);
                        }
                        else if(tipo1 == "real")
                        {
                            real[indice1] = Convert.ToDouble(token.Tokens[2].UserObject);
                        }
                        else
                        {
                            errores = "Error de tipo: " + Convert.ToString(token.Tokens[0].UserObject) + " No es tipo entero o real";
                        }
                    }
                    else
                    {
                        errores = "Error: " + Convert.ToString(token.Tokens[0].UserObject) + " No esta definida";
                    }
                    return null;

                case (int)RuleConstants.RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRAPAR :
                //<Imprimir> ::= imprimir abrepar cierrapar
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRAPAR2 :
                //<Imprimir> ::= imprimir abrepar <Valores Literales> cierrapar
                //todo: Create a new object using the stored user objects.
                salida += Convert.ToString(token.Tokens[2].UserObject) + "\r\n";
                return token.Tokens[2].UserObject;

                case (int)RuleConstants.RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRA :
                //<Imprimir> ::= imprimir abrepar <Val Numericos> cierra
                //todo: Create a new object using the stored user objects.
                salida += Convert.ToString(token.Tokens[2].UserObject) + "\r\n";
                return token.Tokens[2].UserObject;

                case (int)RuleConstants.RULE_IMPRIMIR_IMPRIMIR_ABREPAR_IDENTIFICADOR_CIERRA :
                //<Imprimir> ::= imprimir abrepar Identificador cierra
                //todo: Create a new object using the stored user objects.
                for(int i=0; i < TablaSimbolo.Count; i++)
                    {
                        if(TablaSimbolo[i].id == Convert.ToString(token.Tokens[2].UserObject))
                        {
                            if(TablaSimbolo[i].tipo == "entero")
                            {
                                salida += Convert.ToString(entero[TablaSimbolo[i].indice]) + "\r\n";
                            }else if (TablaSimbolo[i].tipo == "real")
                            {
                                salida += Convert.ToString(real[TablaSimbolo[i].indice]) + "\r\n";
                            }else if (TablaSimbolo[i].tipo == "cadena")
                            {
                                salida += Convert.ToString(cadena[TablaSimbolo[i].indice]) + "\r\n";
                            }else if (TablaSimbolo[i].tipo == "caracter")
                            {
                                salida += Convert.ToString(caracter[TablaSimbolo[i].indice]) + "\r\n";
                            }
                        }
                    }
                    errores = "Error: " + Convert.ToString(token.Tokens[2].UserObject + " No esta definido");
                    return token.Tokens[2].UserObject;

                case (int)RuleConstants.RULE_IMPRIMIR_IMPRIMIR_ABREPAR_CIERRAPAR3 :
                //<Imprimir> ::= imprimir abrepar <Expresion> cierrapar
                //todo: Create a new object using the stored user objects.
                salida += Convert.ToString(token.Tokens[2].UserObject) + "\r\n";
                return token.Tokens[2].UserObject;

                case (int)RuleConstants.RULE_VALORESLITERALES :
                //<Valores Literales> ::= <Val Literales>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_VALORESLITERALES_PLUS :
                //<Valores Literales> ::= <Valores Literales> '+' <Val Literales>
                //todo: Create a new object using the stored user objects.
                return Convert.ToString(token.Tokens[0].UserObject) + Convert.ToString(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_VALORESLITERALES_PLUS_IDENTIFICADOR :
                    //<Valores Literales> ::= <Valores Literales> '+' Identificador
                    //todo: Create a new object using the stored user objects.
                    string cadenaid = string.Empty;
                    for (int i = 0; i < TablaSimbolo.Count; i++)
                    {
                        if (TablaSimbolo[i].id == Convert.ToString(token.Tokens[2].UserObject))
                        {
                            if (TablaSimbolo[i].tipo == "entero")
                            {
                                cadenaid += Convert.ToString(entero[TablaSimbolo[i].indice]);
                            }
                            else if (TablaSimbolo[i].tipo == "real")
                            {
                                cadenaid += Convert.ToString(real[TablaSimbolo[i].indice]);
                            }
                            else if (TablaSimbolo[i].tipo == "cadena")
                            {
                                cadenaid += Convert.ToString(cadena[TablaSimbolo[i].indice]);
                            }
                            else if (TablaSimbolo[i].tipo == "caracter")
                            {
                                cadenaid += Convert.ToString(caracter[TablaSimbolo[i].indice]);
                            }
                            return Convert.ToString(token.Tokens[0].UserObject) + cadenaid;
                        }
                    }
                    errores = "Error: " + Convert.ToString(token.Tokens[2].UserObject + " No esta definido");
                    return token.Tokens[2].UserObject;

                case (int)RuleConstants.RULE_VALLITERALES__CARACTER :
                //<Val Literales> ::= '_caracter'
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_VALLITERALES__CADENA :
                //<Val Literales> ::= '_cadena'
                //todo: Create a new object using the stored user objects.
                return Convert.ToString(token.Tokens[0].UserObject).Trim('"');

                case (int)RuleConstants.RULE_VALNUMERICOS__ENTERO :
                //<Val Numericos> ::= '_entero'
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_VALNUMERICOS__REAL :
                //<Val Numericos> ::= '_real'
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_EXPRESION_PLUS :
                //<Expresion> ::= <Expresion> '+' <Termino>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDecimal(token.Tokens[0].UserObject) + Convert.ToDecimal(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_EXPRESION_MINUS :
                //<Expresion> ::= <Expresion> '-' <Termino>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDecimal(token.Tokens[0].UserObject) - Convert.ToDecimal(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_EXPRESION :
                //<Expresion> ::= <Termino>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_TERMINO_TIMES :
                //<Termino> ::= <Termino> '*' <Factor>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDecimal(token.Tokens[0].UserObject) * Convert.ToDecimal(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_TERMINO_DIV :
                //<Termino> ::= <Termino> '/' <Factor>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDecimal(token.Tokens[0].UserObject) / Convert.ToDecimal(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_TERMINO :
                //<Termino> ::= <Factor>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_FACTOR_ABREPAR_CIERRAPAR :
                //<Factor> ::= abrepar <Expresion> cierrapar
                //todo: Create a new object using the stored user objects.
                return token.Tokens[1].UserObject;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <Val Numericos>
                //todo: Create a new object using the stored user objects.
                return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_FACTOR_IDENTIFICADOR :
                    //<Factor> ::= Identificador
                    //todo: Create a new object using the stored user objects.
                    for (int i = 0; i < TablaSimbolo.Count; i++)
                    {
                        if (TablaSimbolo[i].id == Convert.ToString(token.Tokens[0].UserObject))
                        {
                            if (TablaSimbolo[i].tipo == "entero")
                            {
                                return entero[TablaSimbolo[i].indice];
                            }
                            else if (TablaSimbolo[i].tipo == "real")
                            {
                                return real[TablaSimbolo[i].indice];
                            }
                            else if (TablaSimbolo[i].tipo == "cadena")
                            {
                                return cadena[TablaSimbolo[i].indice];
                            }
                            else if (TablaSimbolo[i].tipo == "caracter")
                            {
                                return caracter[TablaSimbolo[i].indice];
                            }
                            else {
                                errores = "Error de tipo: " + Convert.ToString(token.Tokens[0].UserObject);
                            }
                            return null;
                        }
                    }
                    errores = "Error: " + Convert.ToString(token.Tokens[2].UserObject + " No esta definido");
                    return null;

            }
            throw new RuleException("Unknown rule");

        }
        public static int[] entero = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] real = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        public static string[] cadena = { "", "", "", "", "", "", "", "", "", "", "" };
        public static char[] caracter = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };




        public struct simbolo
        {
            public string id;
            public string tipo;
            public int indice;
        }

        public static List<simbolo> TablaSimbolo = new List<simbolo>();
        public static string salida;
        public static string errores;

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            MessageBox.Show("Analizis Terminado");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            errores = "Error Lexico: " + args.Token.ToString();
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            errores = "ERROR Sintactico: " + args.UnexpectedToken.ToString();
        }


    }
}

