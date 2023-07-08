# Визуелизација на операции со матрици - Matrix-Operations 
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
Апликацијата е составена од неколку форми, првата форма е иницијалната каде што бираме каква операција сакаме да направиме, додека пак следните форми се за внес за одредени информации потребни за бараната операција. Како главна податочна структура која што ја користиме е абстрактна форма која што треба да исцртува 2 матрици во кои што може да се внеусваат вредности за калкулација, како и трета матрица која што го претставува резултатот на операциите. Оваа абстрактна форма ја наследуваат формите за множење и собирање/делење. Има еднa форма за множење и една форма за собирање и делење, бидејќи кај собирање и одземање треба да бидат исти димензиите на двете форми-операнди може да се претстават во една форма, само плус оваа форма има променлива `Mode` која што ги зима вредностите "subtraction" или "addition" и само според тоа врши различна калкулација. Главната функција која што треба да се презапише е `Animate(CancellationToken token)`. Елементите кои што ги има абстрактната форма се следните:
```csharp
public abstract partial class MatrixInputForm : Form
    {
        protected NumericUpDown[,] FirstMatrix;
        protected NumericUpDown[,] SecondMatrix;
        protected TextBox[,] ResultantMatrix;
        protected Button CalculateButton;
        protected Button RandomizeButton;
        protected Button ClearButton;
        protected int XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix;
        protected string Sign;
        protected CancellationTokenSource IterationToken;
        protected TrackBar IterationSpeedPercentage;
        public MatrixInputForm()
        {

        }
        ...
```
Функцијата `Animate()` во формата за собирање и одземање е имплементирана на следниот начин:
```csharp
 protected override async Task Animate(CancellationToken token)
        {
            CalculateButton.Enabled = false;
            RandomizeButton.Enabled = false;
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < FirstMatrix.GetLength(1); j++)
                {
                    FirstMatrix[i, j].BackColor = Color.LightGreen;
                    SecondMatrix[i, j].BackColor = Color.LightGreen;
                    ResultantMatrix[i, j].BackColor = Color.LightGreen;
                    switch (Mode)
                    {
                        case "addition":
                            ResultantMatrix[i, j].Text = $"{FirstMatrix[i, j].Value + SecondMatrix[i, j].Value}";
                            break;
                        case "subtraction":
                            ResultantMatrix[i, j].Text = $"{FirstMatrix[i, j].Value - SecondMatrix[i, j].Value}";
                            break;
                    }
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
                FirstMatrix[i, j].BackColor = Color.White;
                SecondMatrix[i, j].BackColor = Color.White;
                ResultantMatrix[i, j].BackColor = Color.White;
                }
            }

        }
```
Додека пак функцијата `Animate()` во формата за множење е имплементирана на следниот начин:
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
Методите и варијаблите за иницијализација на формата која ги прикажува влезните полиња се наоѓаат во директориумот `Initialization files/MatrixInputForm`. Во фајловите ни се потребни одредени глобални променливи кои се однесуваат на ширина, должина на дадени компоненти, маргини и слични други карактеристики. Овие променливи ни се дефинирани во статичката класа `Variables.cs`. Во статичката класа `MatrixInit` се наоѓаат методи за иницијализација на полињата за внес на вредности во матриците и знаците измеѓу нив. Една матрица од матриците кои учествуваат во операцијата се генерира на следниот начин:
```csharp
public static NumericUpDown[,] GenerateMatrix(MatrixInputForm form, int X, int Y,
                                    int MarginX, int MarginY)
        {
            NumericUpDown[,] numericUpDowns = new NumericUpDown[X, Y];

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    numericUpDowns[i, j] = new NumericUpDown();
                    numericUpDowns[i, j].Top = MarginY + i * Variables.FieldsTotalHeight;
                    numericUpDowns[i, j].Left = MarginX + j * Variables.FieldsTotalWidth;
                    numericUpDowns[i, j].Width = Variables.FieldsWidth;
                    numericUpDowns[i, j].Minimum = -10000;
                    form.Controls.Add(numericUpDowns[i, j]);
                }
            }

            return numericUpDowns;
        }
```
За генерирање на резултантната матрица се користи слична функција `GenerateDisabledTextBoxMatrix` која прави матрица од `TextBox` полиња кои се disabled, користи код кој е сличен на претходниот само наместо користење на `NumericUpDown` типот се користи `TextBox` типот и наместо користење на атрибутот `Minimum` се поставува атрибутот `Enabled` на келијата на `false`. Функцијата `GenerateMatrix` подоцна се користи во соодветната функција за генерирање на матрица, како функцијата `GenerateFirstMatrix` која воедно пресметува маргина за првата матрицата и го повикува методот `GenerateMatrix` и функцијата `GenerateSecondMatrix` која соодветно пресметува маргина за втората матрица и го повикува методот `GenerateMatrix`. Функцијата `GenerateResultingMatrix` се однесува слично како претходно наведените функции, но ја повикува функцијата `GenerateDisabledTextBoxMatrix` наместо `GenerateMatrix`. Може да се види `GenerateFirstMatrix` во продолжение:
```csharp
private static NumericUpDown[,] GenerateFirstMatrix(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int CenterMarginYFirstMatrix)
        {
            // <summary>
            // Generates the first matrix
            //</summary>
            int MarginXForFirstMatrix = Variables.LeftOffset;
            int MarginYForFirstMatrix = Variables.TopOffset + CenterMarginYFirstMatrix;



            return GenerateMatrix(form, XFirstMatrix, YFirstMatrix, MarginXForFirstMatrix,
                MarginYForFirstMatrix);

        }
```
За генерирање на знаците се користи функцијата `GenerateSigns`:
```csharp
private static (Label, Label) GenerateSigns(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            int PositionOperationY = GenerateOperationSignY(XFirstMatrix, XSecondMatrix);
            int PositionEqualsY = GenerateEqualsSignY(XFirstMatrix, XSecondMatrix);
            int PositionOperationX = GenerateOperationSignX(YFirstMatrix);
            int PositionEqualsX = GenerateEqualsSignX(YFirstMatrix, YSecondMatrix);


            Label OperationLabel = GenerateLabel(PositionOperationY, PositionOperationX, new Size(Variables.FontOperationWidth, Variables.FontEqualsHeight), Sign);
            Label EqualsLabel = GenerateLabel(PositionEqualsY, PositionEqualsX, new Size(Variables.FontEqualsWidth, Variables.FontEqualsHeight), "="); ;

            return (OperationLabel, EqualsLabel);

        }
```
Со функциите `GenerateEqualsSignX`, `GenerateEqualsSignY`, `GenerateOperationSignX`, `GenerateOperationSignY` се генерираат координатите на знакот еднакво и знакот на операцијата во однос на бројот на редици и колони на внесените матрици, како и земајќи ги во предвид маргините од статичката класа `Variables`. Функцијата `GenerateLabel` генерира `Label` компонента и како аргументи ги зема `Top`, `Left`, `Size`, `Text` атрибутите на лабелата. 

За иницијализација на помошните контроли како лабели, копчиња и трек-барот ќе ги користиме методите од `HelperControlsInit` статичката класа. Во оваа класа има методи за иницијализација на лабелите на матриците. Ваквите методи генераат соодветна лабела која е центрирана на средина на матрицата и над неа. Пример за ваков метод е `GenerateFirstMatrixLabel`.
```csharp
public static void GenerateFirstMatrixLabel(this MatrixInputForm form, int YFirstMatrix)
        {
            Label Label = new Label();
            Label.Text = "First matrix";
            Label.Top = Variables.TopOffset - Variables.DistanceFromMatrixes;
            Label.Left = Variables.LeftOffset + (YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft - Label.Width) / 2;
            form.Controls.Add(Label);
        }
```
Во оваа класа го има и методот `SetWidthAndHeight` за динамичко одредување на големината на формата во зависност од внесените полиња:
```csharp
public static void SetWidthAndHeight(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix)
        {
            (int XResultantMatrix, int YResultantMatrix) = (XFirstMatrix, YSecondMatrix);
            form.Width = (YFirstMatrix + YSecondMatrix + YResultantMatrix) * Variables.FieldsTotalWidth + Variables.MatrixDistance * 2 + Variables.LeftOffset + Variables.RightOffset;
            form.Height = Math.Max(XFirstMatrix, XSecondMatrix) * Variables.FieldsTotalHeight + Variables.TopOffset + Variables.BottomOffset;

        }
```
## Изглед/Приказ на апликацијата
### Собирање
![](https://github.com/alekjarmov/Matrix-Operations/blob/main/documentation/addition.gif)
### Одземање
![](https://github.com/alekjarmov/Matrix-Operations/blob/main/documentation/subtraction.gif)
### Множење
![](https://github.com/alekjarmov/Matrix-Operations/blob/main/documentation/multiplication.gif)
