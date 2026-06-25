string studentName = "TASHYAK";
string course1Name = "DSA";
string course2Name = "DBMS";
string course3Name = "Operating Systems";
string course4Name = "Machine Learning";
string course5Name = "Computer Networks";
Random random = new Random();
int course1Credit = random.Next(1, 5);
int course2Credit = random.Next(1, 5);
int course3Credit = random.Next(1, 5);
int course4Credit = random.Next(1, 5);
int course5Credit = random.Next(1, 5);

int gradeA = random.Next(1, 10);
int gradeB = random.Next(1, 10);

int course1Grade = gradeA;
int course2Grade = gradeB;
int course3Grade = gradeB;
int course4Grade = gradeB;
int course5Grade = gradeA;

int totalCreditHours = 0;
totalCreditHours += course1Credit;
totalCreditHours += course2Credit;
totalCreditHours += course3Credit;
totalCreditHours += course4Credit;
totalCreditHours += course5Credit;

int totalGradePoints = 0;
totalGradePoints += course1Credit * course1Grade;
totalGradePoints += course2Credit * course2Grade;
totalGradePoints += course3Credit * course3Grade;
totalGradePoints += course4Credit * course4Grade;
totalGradePoints += course5Credit * course5Grade;

decimal gradePointAverage = (decimal) totalGradePoints/totalCreditHours;

int leadingDigit = (int) gradePointAverage;
int firstDigit = (int) (gradePointAverage * 10 ) % 10;
int secondDigit = (int) (gradePointAverage * 100 ) % 10;

// Display the results
Console.WriteLine($"Student: {studentName}\n");
Console.WriteLine("╔═════════════════════════╦═══════╦══════════════╗");
Console.WriteLine("║ Course                  ║ Grade ║ Credit Hours ║");
Console.WriteLine("╠═════════════════════════╬═══════╬══════════════╣");
Console.WriteLine($"║ {course1Name,-23} ║ {course1Grade,5} ║ {course1Credit,12} ║");
Console.WriteLine($"║ {course2Name,-23} ║ {course2Grade,5} ║ {course2Credit,12} ║");
Console.WriteLine($"║ {course3Name,-23} ║ {course3Grade,5} ║ {course3Credit,12} ║");
Console.WriteLine($"║ {course4Name,-23} ║ {course4Grade,5} ║ {course4Credit,12} ║");
Console.WriteLine($"║ {course5Name,-23} ║ {course5Grade,5} ║ {course5Credit,12} ║");
Console.WriteLine("╚═════════════════════════╩═══════╩══════════════╝");

Console.WriteLine($"\nFinal GPA:\t\t{leadingDigit}.{firstDigit}{secondDigit}");