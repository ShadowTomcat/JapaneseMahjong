# JapaneseMahjong
暂时是日本麻将的库，目标是做成游戏和麻将AI

示例代码：
```csharp
static void Main() {
    const int N = 50;

    Stopwatch sw = new Stopwatch();

    var game = Game.Instance;
    var tiles = new SortedTilesEnumerator(game.GetRandomTiles(14).Select(t => t.BaseTile));
    //var tiles = BaseTile.ParseSuffixExpr("1112345678999m1m");
    Console.WriteLine(string.Concat<BaseTile>(tiles));
    Console.WriteLine(BaseTile.ToSuffixExpr(tiles));
    Console.WriteLine();
    SuggestResult suggest = null;
    sw.Restart();
    for (int i = 0; i < N; i++) suggest = game.Suggest(tiles);
    sw.Stop();
    Console.WriteLine($"提供建议平均耗时：{TimeSpan.FromTicks(sw.Elapsed.Ticks / N)}");
    Console.WriteLine(suggest);
    Console.WriteLine(string.Join(Environment.NewLine, suggest.Values));
    Console.WriteLine();

    var tiles2 = game.GetTiles(tiles).ToArray();
    tiles2.Last().Owner = Wind.东;
    if (game.TestRon(tiles2)) {
        var a = game.Analysis(tiles2);
        if (a != null) {
            Console.WriteLine(string.Join(Environment.NewLine, a));
            Console.WriteLine();
        }
        var score = game.GetScore(tiles2, null, YakuEnvironment.门前清 | YakuEnvironment.自摸);
        Console.WriteLine(score);
        Console.WriteLine(string.Join<YakuValue>(Environment.NewLine, score.YakuValues));
        Console.WriteLine();
    }
}

```

![](https://github.com/ibukisaar/JapaneseMahjong/raw/master/imgs/QQ截图20170915135745.png)
![](https://github.com/ibukisaar/JapaneseMahjong/raw/master/imgs/QQ截图20170915134408.png)
![](https://github.com/ibukisaar/JapaneseMahjong/raw/master/imgs/QQ截图20170915140105.png)
![](https://github.com/ibukisaar/JapaneseMahjong/raw/master/imgs/QQ截图20170915134517.png)
![](https://github.com/ibukisaar/JapaneseMahjong/raw/master/imgs/QQ截图20170915134703.png)
![](https://github.com/ibukisaar/JapaneseMahjong/raw/master/imgs/QQ截图20170915134738.png)
![](https://github.com/ibukisaar/JapaneseMahjong/raw/master/imgs/QQ截图20170915134810.png)