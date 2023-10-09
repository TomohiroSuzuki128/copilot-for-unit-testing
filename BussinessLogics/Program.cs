// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// 消費税を込みの価格を計算するメソッド
decimal CalcTaxIncludedPrice(decimal price)
{
    // 消費税を計算する
    var tax = price * 0.1m;
    // 消費税を加えた価格を計算する
    var taxIncludedPrice = price + tax;
    // 小数点以下を切り捨てる
    return Math.Floor(taxIncludedPrice);
}


// 軽減税率を考慮し消費税を込みの価格を計算するメソッド
decimal CalcTaxIncludedPrice(decimal price, bool isReducedTaxRate)
{
    // 軽減税率の場合は8%、それ以外は10%の消費税を計算する
    var taxRate = isReducedTaxRate ? 0.08m : 0.1m;
    // 消費税を計算する
    var tax = price * taxRate;
    // 消費税を加えた価格を計算する
    var taxIncludedPrice = price + tax;
    // 小数点以下を切り捨てる
    return Math.Floor(taxIncludedPrice);
}

//　住所を都道府県、市町村、それ以下に分割するメソッド
(string prefecture, string city, string town) SplitAddress(string address)
{
    // 住所を分割する
    var addressArray = address.Split(' ');
    // 都道府県を取得する
    var prefecture = addressArray[0];
    // 市町村を取得する
    var city = addressArray[1];
    // それ以下を取得する
    var town = addressArray[2];
    // 都道府県、市町村、それ以下をタプルで返す
    return (prefecture, city, town);
}

//　「都、道、府、県」という文字を目印に都道府県部分を取り出し「市、区、町、村、郡」という文字を目印に、市区町村群を取り出し、最終的に与えられた住所を都道府県、市町村、それ以下の3つに分割するメソッド
(string prefecture, string city, string town) SplitAddress2(string address)
{
    // 住所を分割する
    var prefectureIndex = address.IndexOf("都") + 1;
    var cityIndex = address.IndexOf("道") + 1;
    var townIndex = address.IndexOf("府") + 1;
    var kenIndex = address.IndexOf("県") + 1;
    var prefecture = address.Substring(0, prefectureIndex);
    var city = address.Substring(prefectureIndex, cityIndex - prefectureIndex);
    var town = address.Substring(cityIndex, townIndex - cityIndex);
    // 都道府県、市町村、それ以下をタプルで返す
    return (prefecture, city, town);
}

//　「都」または「道」または「府」または「県」という文字の位置を目印に住所の文字列から都道府県に相当する部分の文字列を取り出し、次に「市」または「区」または「町」または「村」または「郡」という文字の位置を目印に、住所の文字列から市区町村群に相当する部分の文字列を取り出し、残った文字列をそれ以下として取り出すことで、最終的に与えられた住所の文字列を「都道府県」、「市区町村郡」、「それ以下」の3つに分割するメソッド
(string prefecture, string city, string town) SplitAddress3(string address)
{
    // 住所を分割する
    var prefectureIndex = address.IndexOf("都");
    if (prefectureIndex == -1)
    {
        prefectureIndex = address.IndexOf("道");
        if (prefectureIndex == -1)
        {
            prefectureIndex = address.IndexOf("府");
            if (prefectureIndex == -1)
            {
                prefectureIndex = address.IndexOf("県");
            }
        }
    }
    var cityIndex = address.IndexOf("市");
    if (cityIndex == -1)
    {
        cityIndex = address.IndexOf("区");
        if (cityIndex == -1)
        {
            cityIndex = address.IndexOf("町");
            if (cityIndex == -1)
            {
                cityIndex = address.IndexOf("村");
                if (cityIndex == -1)
                {
                    cityIndex = address.IndexOf("郡");
                }
            }
        }
    }
    var prefecture = address.Substring(0, prefectureIndex + 1);
    var city = address.Substring(prefectureIndex + 1, cityIndex - prefectureIndex);
    var town = address.Substring(cityIndex + 1);
    // 都道府県、市町村、それ以下をタプルで返す
    return (prefecture, city, town);
}














