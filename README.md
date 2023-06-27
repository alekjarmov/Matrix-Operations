# Визуелзиација на операции со матрици - Matrix-Operations 
Проект изработен од Алек Јармов и Ана Марија Атанасовска

## Опис на апликацијата
Апликацијата е наменета како еден вид на калкулатор за разни операции со матрици. Освен што треба да се прикажува резултатот од операциите исто така треба да се прикажува визуелен приказ
со што полесно може да се сфати како точно работат алгоритмите за извршување на одредени операции со матрици.

## Подржани операции
![image](https://github.com/alekjarmov/Matrix-Operations/assets/6871971/df34e8dc-3b35-49a7-a5f4-7fd208814a7f)

На почеток на апликацијата е прикажано мени со подржаните операции со матрици. Корисникот треба да ја избере саканата операција и да притисне на копчето `SHOW OPERATION`.
По притискање на копчето се преминува на бараниот алгоритам.

### Собирање
![image](https://github.com/alekjarmov/Matrix-Operations/assets/6871971/c8a5d25e-f298-4080-87ab-0dea8706495a)

Апликацијата подржува собирање на 2 матрици. Две матрици може да се соберат само доколку имаат исти димензии, па доколку е избрана оваа опција следно треба да се внесат димензиите на матриците
кои што ќе се собираат. По внесување на димензиите треба да се притисне копчето `Go to A+B calculator`, што ќе не пренесе на нова форма каде што се внесуваат матриците кои што сакаме да ги собереме
и го прикажува самиот процес на собирање на матриците како и резултатот. 

### Одземање
![image](https://github.com/alekjarmov/Matrix-Operations/assets/6871971/0cfb56e0-862c-4fe9-92e2-8501bb1122ad)

Подржано е и одземање на 2 матрици. Две матрици може да се одземат само доколку имаат исти димензии, па доколку е избрана оваа опција следно треба да се внесат димензиите на матриците
кои што ќе се одземаат. По внесување на димензиите треба да се притисне копчето `Go to A-B calculator`, што ќе не пренесе на нова форма каде што се внесуваат матриците кои што сакаме да ги одземеме
и го прикажува самиот процес на одземање на матриците како и резултатот.

### Множење
![image](https://github.com/alekjarmov/Matrix-Operations/assets/6871971/6a30ef16-be64-4157-8895-b3e24085b900)

Кога сакаме да множиме 2 матрици тие може да имаат различни димензии за разлика од собирање и одземање. На прикажаната форма треба да се внесат димензиите на двете матрици.
Доколку димензиите на првата матрица се `(m,n)` а димензиите на втората матрица се `(k,l)`, тогаш мора да важи `n=k` за да сме сигурни дека ова важи при промена на едниот NumericUpDown автоматски
се менува и другиот, тоа е просто постигнато со следниот код:
```csharp
private void YFirstMatrix_ValueChanged(object sender, EventArgs e)
{
    XSecondMatrix.Value = YFirstMatrix.Value;
}
private void XSecondMatrix_ValueChanged(object sender, EventArgs e)
{
    YFirstMatrix.Value = XSecondMatrix.Value;
}
```
### Општи забелешки
На делот каде што се внесуваат двете матрици врз кои што сакаме да направиме една од операциите собирање, одземање или множење се понудени опции кои што треба да го подобрат искуството на корисникот, како на пример можноста да се избришат сите моментално внесени вредности или пак да се наполнат матриците со случајно генерирани вредности. Освен ова корисникот може да ја менува брзината на анимацијата која што го прикажува процесот за извршување на калкулација.

## Имплементација и податочни структури
Како главна податочна структура која што ја користиме е абстрактна форма која што треба да исцртува 2 матрици во кои што може да се внеусваат вредности за калкулација, како и трета матрица која што го претставува резултатот на операциите. Оваа абстрактна форма ја наследуваат формите за множење и собирање/делење. Има еднa форма за множење и една форма за собирање и делење, бидејќи кај собирање и одземање треба да бидат исти димензиите на двете форми-операнди може да се претстават во една форма, само плус оваа форма има променлива `Mode` која што ги зима вредностите "subtraction" или "addition" и само според тоа врши различна калкулација. Главната функција која што треба да се презапише е `Animate(CancellationToken token)`. Елементите кои што ги има абстрактната форма се следните:
```csharp

```

Функцијата која што ги прави и прикажува калкулациите за множење на 2 матрици е следнава:
```csharp
protected override async Task Animate(CancellationToken token)
        {
            CalculateButton.Enabled = false;
            RandomizeButton.Enabled = false;
            this.ResetResultantMatrix();
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int x = 0; x < FirstMatrix.GetLength(1); x++)
                {
                    FirstMatrix[i, x].BackColor = Color.LightGreen;
                }

                for (int j = 0; j < SecondMatrix.GetLength(1); j++)
                {
                    for (int x = 0; x < SecondMatrix.GetLength(0); x++)
                    {
                        SecondMatrix[x, j].BackColor = Color.LightGreen;
                    }
                    for (int k = 0; k < SecondMatrix.GetLength(0); k++)
                    {
                        
                        FirstMatrix[i, k].BackColor = Color.LightPink;
                        SecondMatrix[k, j].BackColor = Color.LightPink;
                        ResultantMatrix[i, j].BackColor = Color.LightPink;
                        ResultantMatrix[i, j].ForeColor = Color.Black;
                        int ParsedResultantMatrixText = 0;

                        if (!ResultantMatrix[i, j].Text.Equals(""))
                            ParsedResultantMatrixText = Int32.Parse(ResultantMatrix[i, j].Text);
                        ResultantMatrix[i, j].Text = $"{ParsedResultantMatrixText + (FirstMatrix[i, k].Value * SecondMatrix[k, j].Value)}";
                        try
                        {
                            token.ThrowIfCancellationRequested();
                            await Task.Delay(this.CalculateDelay());
                        }
                        catch (OperationCanceledException ex)
                        {
                            ResetColorNumericUpDowns();
                            ResetResultantMatrix();
                            return;
                        }
                        FirstMatrix[i, k].BackColor = Color.LightGreen;
                        SecondMatrix[k, j].BackColor = Color.LightGreen;
                    }
                    for (int x = 0; x < SecondMatrix.GetLength(0); x++)
                    {
                        SecondMatrix[x, j].BackColor = Color.White;
                    }
                    ResultantMatrix[i, j].BackColor = Color.White;

                }
                for (int x = 0; x < FirstMatrix.GetLength(1); x++)
                {
                    FirstMatrix[i, x].BackColor = Color.White;
                }
            }
        }
```
