using System;
using System.Collections.Generic;

public class TreeNode
{
    public string Value { get; }
    public string Direction { get; }
    public List<TreeNode> Children { get; }

    public TreeNode(string value, string direction = "")
    {
        Value = value;
        Direction = direction;
        Children = new List<TreeNode>();
    }

    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }

    public override string ToString()
    {
        return $"{Direction} {Value}".Trim();
    }
}

public class ParseTree
{
    public TreeNode Root { get; }

    public ParseTree(string startSymbol)
    {
        Root = new TreeNode(startSymbol);
    }

    public void BuildTree(TreeNode currentNode, string currentState, string inputSymbol, string direction)
    {
        TreeNode newNode = new TreeNode($"q{currentState} - {inputSymbol}", direction);
        currentNode.AddChild(newNode);
    }
}

public class ScannerAFD
{
    private int[] estadosAceptacion = { 4 };
    private ParseTree parseTree;
    public TreeNode Root => parseTree.Root;

    private Dictionary<(int, char), string> direcciones = new Dictionary<(int, char), string>
    {
        { (0, 'a'), "Derecha" },
        { (1, 'b'), "Derecha" },
        { (2, 'a'), "Derecha" },
        { (3, 'a'), "Derecha" },
        { (3, 'b'), "Izquierda" },
        { (3, '*'), "Derecha" },
        { (4, '#'), "Derecha" },
        { (4, 'a'), "Izquierda" },
        { (4, 'b'), "Izquierda" }
    };

    private int Estado0(char letra)
    {
        if (letra == 'a') return 1;
        throw new Exception($"Letra '{letra}' no reconocida en el estado 0");
    }

    private int Estado1(char letra)
    {
        if (letra == 'b') return 2;
        throw new Exception($"Letra '{letra}' no reconocida en el estado 1");
    }

    private int Estado2(char letra)
    {
        if (letra == 'a') return 3;
        throw new Exception($"Letra '{letra}' no reconocida en el estado 2");
    }

    private int Estado3(char letra)
    {
        if (letra == 'a') return 3;
        if (letra == 'b') return 1;
        if (letra == '*') return 4;
        throw new Exception($"Letra '{letra}' no reconocida en el estado 3");
    }

    private int Estado4(char letra)
    {
        if (letra == '#') return 4;
        if (letra == 'a') return 3;
        if (letra == 'b') return 1;
        throw new Exception($"Letra '{letra}' no reconocida en el estado 4");
    }

    private bool EsEstadoAceptacion(int estado)
    {
        foreach (int i in estadosAceptacion)
        {
            if (i == estado) return true;
        }
        return false;
    }

    public bool EsAceptada(string input)
    {
        int estadoActual = 0;
        parseTree = new ParseTree("q0");
        TreeNode nodoActual = parseTree.Root;

        foreach (char letra in input)
        {
            int nuevoEstado;
            string direction = direcciones.ContainsKey((estadoActual, letra)) ? direcciones[(estadoActual, letra)] : "No definido";

            try
            {
                if (estadoActual == 0) nuevoEstado = Estado0(letra);
                else if (estadoActual == 1) nuevoEstado = Estado1(letra);
                else if (estadoActual == 2) nuevoEstado = Estado2(letra);
                else if (estadoActual == 3) nuevoEstado = Estado3(letra);
                else if (estadoActual == 4) nuevoEstado = Estado4(letra);
                else throw new Exception("Estado no reconocido");

                parseTree.BuildTree(nodoActual, nuevoEstado.ToString(), letra.ToString(), direction);
                nodoActual = nodoActual.Children[nodoActual.Children.Count - 1];
                estadoActual = nuevoEstado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        return EsEstadoAceptacion(estadoActual);
    }

    public void ImprimirTabla(string input)
    {
        Dictionary<string, Dictionary<char, string>> tablaTransiciones = new Dictionary<string, Dictionary<char, string>>();
        int estadoActual = 0;

        foreach (char letra in input)
        {
            int nuevoEstado;
            if (estadoActual == 0) nuevoEstado = Estado0(letra);
            else if (estadoActual == 1) nuevoEstado = Estado1(letra);
            else if (estadoActual == 2) nuevoEstado = Estado2(letra);
            else if (estadoActual == 3) nuevoEstado = Estado3(letra);
            else if (estadoActual == 4) nuevoEstado = Estado4(letra);
            else throw new Exception("Estado no reconocido");

            string estadoActualStr = $"q{estadoActual}";
            string nuevoEstadoStr = $"q{nuevoEstado}";

            if (!tablaTransiciones.ContainsKey(estadoActualStr))
            {
                tablaTransiciones[estadoActualStr] = new Dictionary<char, string>();
            }
            tablaTransiciones[estadoActualStr][letra] = nuevoEstadoStr;
            estadoActual = nuevoEstado;
        }

        char[] caracteres = { 'a', 'b', '*', '#' };

        Console.WriteLine("      a     b     *     #");
        Console.WriteLine("    ------------------------");

        foreach (var estado in tablaTransiciones)
        {
            Console.Write($"{estado.Key}  ");
            foreach (var caracter in caracteres)
            {
                if (estado.Value.ContainsKey(caracter))
                {
                    Console.Write($"{estado.Value[caracter],-5} ");
                }
                else
                {
                    Console.Write($"{"-",-5} ");
                }
            }
            Console.WriteLine();
        }
    }
}

public class TreeVisualizer
{
    public static void PrintTree(TreeNode node, string indent = "", bool last = true)
    {
        Console.Write(indent);
        if (last)
        {
            Console.Write("└─");
            indent += "  ";
        }
        else
        {
            Console.Write("├─");
            indent += "| ";
        }
        Console.WriteLine(node.ToString());

        for (int i = 0; i < node.Children.Count; i++)
        {
            PrintTree(node.Children[i], indent, i == node.Children.Count - 1);
        }
    }
}





