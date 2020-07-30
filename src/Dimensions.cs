using System;

public class Dimensions
{
    public decimal Height { get; private set; }
    public decimal Width { get; private set; }
    public decimal Depth { get; private set; }

    public Dimensoes(decimal height, decimal width, decimal depth)
    {
        Validacoes.ValidarSeMenorQue(height, 1, "O campo Altura não pode ser menor ou igual a 0");
        Validacoes.ValidarSeMenorQue(largura, 1, "O campo Largura não pode ser menor ou igual a 0");
        Validacoes.ValidarSeMenorQue(profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");

        Height = height;
        Width = width;
        Depth = depth;
    }

    public override string ToString()
    {
        return $"WidthxHeightxDepth: {Width} x {Height} x {Depth}";
    }
}
