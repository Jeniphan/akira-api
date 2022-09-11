namespace akiira_api.models
{
  public class character
  {
    public int Id { get; set; }
    public string Name { get; set; } = "Akiira";
    public int HitPoint { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Intalligence { get; set; } = 10;
    public akiiraClass Class { get; set; } = akiiraClass.Knight;
  }
}