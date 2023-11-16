#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

#define Normal_Color 0x07
#define Highlight_Color 0x20

#define ENTER_KEY 13
#define ESC_KEY 27
#define HOME_KEY 71
#define END_KEY 79
#define TAB_KEY 9
#define PAGE_UP_KEY 73
#define PAGE_DN_KEY 81
#define ARROW_UP_KEY 72
#define ARROW_DOWN_KEY 80
#define ARROW_RIGHT_KEY 77
#define ARROW_LEFT_KEY 75


/// Define a structure to represent employee information
typedef struct emp
{
    int id;
    char name[20];
    float salary;
    float bonus;
    float deduction;
} Employee;

Employee employees[50];

int pos = 0;
char ch;
int flag = 0;
int index = 0; ///To Know index of employee
int secID; ///Send ID to search

void gotoxy(int x, int y);
void textattr(int i);
void Menu();
void switchMenu();
void clrscr();
void addEmployee(Employee[], int);
void employeeData();
void deleteEmployee(Employee emp[], int id);
void display_data(Employee emp[], int index);
void displayAllEmployees(Employee emp[],int size);
void deleteAllEmployee(Employee emp[]);
void showData(Employee emp[],int x);
void sortEmployee();


int main()
{
    Menu();
    return 0;
}

///Draw Outer Border
void draw_border()
{
    ///Upper Row
    for(int i = 40 ; i <101 ; i++)
    {
        gotoxy(i,6);
        printf("%c",220);
    }

    ///Right Column
    for(int i = 7 ; i <22 ; i++)
    {
        gotoxy(100,i);
        printf("%c",219);
    }

    ///Lower Row
    for(int i = 40 ; i <100 ; i++)
    {
        gotoxy(i,21);
        printf("%c",220);
    }

    ///Left Column
    for(int i = 7 ; i <22 ; i++)
    {
        gotoxy(40,i);
        printf("%c",219);
    }
}

///Display Menu
void Menu()
{
    char Menuu[6][40] = {"1-) Add new employee!",
                         "2-) Display Specific Employee!",
                         "3-) Display All Employee!",
                         "4-) Delete Specific Employee!",
                         "5-) Delete All Employee!",
                         "6-) Exit!"
                        };
    do
    {
        textattr(Normal_Color);
        clrscr();
        draw_border();
        gotoxy(61,8);
        printf("%d", index);
        printf("=====Menu=====");
        gotoxy(62,8);
        for(int i = 0 ; i < 6 ; i++)
        {
            if(pos == i)
            {
                textattr(Highlight_Color);
            }
            else
            {
                textattr(Normal_Color);
            }
            gotoxy(55, 10 + i*2);
            printf("%s\n", Menuu[i]);
        }
        printf("\n");
        printf("%d", index);
        switchMenu();
    }
    while(flag == 0);
}

///Menu Controls
void switchMenu()
{

    ch = getch();
    switch(ch)
    {
    case ENTER_KEY:
        switch(pos)
        {
        case  0:
            clrscr();
            addEmployee(employees,index);
            index++;
            getche();
            break;
        case 1:
            textattr(Normal_Color);
            clrscr();
            gotoxy(55,5);
            printf(">> Enter the employee id:");
            gotoxy(85, 5);
            scanf("%d", &secID);
            display_data(employees,secID);
            getch();
            break;
        case 2:
            clrscr();
            displayAllEmployees(employees,index);
            getche();
            break;
        case 3:
            clrscr();
            draw_border();
            gotoxy(52, 8);
            printf("=========Delete Employee Data=========\n");
            gotoxy(55, 10);
            printf("Emp ID you would like to delete:\n");
            gotoxy(87, 10);
            scanf("%d", &secID);
            deleteEmployee(employees, secID);
            getche();
            break;
        case 4:
            clrscr();
            deleteAllEmployee(employees);
            getche();
            break;
        case 5:
            clrscr();
            flag = 1;
            textattr(Normal_Color);
            break;
        default:
            flag = 0;
            break;
        }
        break;
    case ESC_KEY:
        clrscr();
        printf("");
        flag = 1;
        break;
    case TAB_KEY:
        pos = ++pos > 5 ? 0 : pos;
        break;
    case 224:
    case 0:
    case -32:
        ch = getch();
        switch (ch)
        {
        case ARROW_UP_KEY:
            pos = --pos < 0 ? 5 : pos;
            break;
        case ARROW_DOWN_KEY:
            pos = ++pos > 5 ? 0 : pos;
            break;
        case PAGE_UP_KEY:
            pos = --pos < 0 ? 5 : pos;
            break;
        case PAGE_DN_KEY:
            pos = ++pos > 5 ? 0 : pos;
            break;
        case HOME_KEY:
            pos = 0;
            break;
        case END_KEY:
            pos = 5;
            break;
        }
    }
}

void gotoxy(int x, int y)
{
    COORD coord;
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

void textattr(int i)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

///Hide Cursor
void hidecursor()
{
    HANDLE consoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);
    CONSOLE_CURSOR_INFO info;
    info.dwSize = 100;
    info.bVisible = FALSE;
    SetConsoleCursorInfo(consoleHandle, &info);
}

///Clear screen
void clrscr()
{
    system("cls");
}

///Add New Employee
void employeeData()
{
    draw_border();
    gotoxy(55, 8);
    printf("=====Add a New Employee=====\n");
    gotoxy(55, 10);
    printf("1-) Employee ID:");
    gotoxy(55, 12);
    printf("2-) Emplyee Name:");
    gotoxy(55, 14);
    printf("3-) Salary:");
    gotoxy(55, 16);
    printf("4-) Bonus:");
    gotoxy(55, 18);
    printf("5-) Deduction:");
}


///Add New Employee (structure)
void addEmployee(Employee emp[], int index)
{
    draw_border();
    employeeData();
    gotoxy(73, 10);
    scanf("%d", &emp[index].id);
    fflush(stdin);
    gotoxy(73, 12);
    gets(emp[index].name);
    fflush(stdin);
    gotoxy(68, 14);
    scanf(" %f",&emp[index].salary);
    fflush(stdin);
    gotoxy(68, 16);
    scanf(" %f",&emp[index].bonus);
    fflush(stdin);
    gotoxy(70, 18);
    scanf(" %f",&emp[index].deduction);
    fflush(stdin);
}
///Display Data
void showData( Employee emp[],int x)
{
    textattr(Normal_Color);
    clrscr();
    draw_border();
    gotoxy(55, 8);
    printf("=========Employee Data=========\n");
    gotoxy(55, 10);
    printf("Employee Code: %d\n", emp[x].id);
    gotoxy(55, 12);
    printf("Employee Name: %s\n", emp[x].name);
    gotoxy(55, 14);
    printf("Employee Salary: %.2f\n", emp[x].salary);
    gotoxy(55, 16);
    printf("Employee Salary: %.2f\n", emp[x].bonus);
    gotoxy(55, 18);
    printf("Employee Salary: %.2f\n", emp[x].deduction);
    /// Calculate the net salary
    float netSalary = emp[x].salary + emp[x].bonus - emp[x].deduction;
    gotoxy(55, 20);
    printf("Net Salary: %0.2f\n", netSalary);
}

///Display Employee data
void display_data(Employee emp[], int id)
{
    int x;
    int temp = 1;
    for( int i = 0 ; i < 50 ; i++)
    {
        if(emp[i].id == id)
        {
            temp = 1;
            x =i;
            break;
        }
        else
        {
            temp = 0;
        }
    }
    if(temp = 1)
    {
        showData(emp,x);
    }
    else
    {
        gotoxy(55, 20);
        printf("=========Employee Not Found=========\n");
    }

}


///Display All Employee Data With Swithching
void displayAllEmployees(Employee emp[], int size)
{
    int i = 0, exit = 0;
    char key;

    do
    {
        showData(emp,i);
        key = getch();
        switch (key)
        {
        case -32:
            switch (getch())
            {
            case ARROW_RIGHT_KEY:
                i = ++i > size - 1 ? 0 : i;
                break;
            case ARROW_LEFT_KEY:
                i = --i < 0 ? size - 1 : i;
                break;
            }
            break;
        default:
            exit = 1;
            break;
        }
    }
    while (!exit);
}



///Delete Employee Data
void deleteEmployee(Employee emp[], int id)
{
    draw_border();
    int x;
    int temp = 1;
    for( int i = 0 ; i < 50 ; i++)
    {
        if(emp[i].id == id)
        {
            temp = 1;
            x = i;
            break;
        }
        else
        {
            temp = 0;
        }
    }
    if(temp = 1)
    {
        for( int i = x ; i < 50 ; i++)
        {
            emp[i]= emp[i + 1];
        }
        index--;
        gotoxy(55, 15);
        printf("Employee with ID '%d' deleted successfuly", id);
    }
    else
    {
        gotoxy(55, 12);
        printf("There is no Employee with this ID:\n");
    }
}

///Delete All Employees Data
void deleteAllEmployee(Employee emp[])
{
    draw_border();
    hidecursor();
    for( int i = 0 ; i < 49 ; i++)
    {
        emp[i]= emp[i + 1];
    }
    index = 0;
    gotoxy(55, 13);
    printf("All Employee deleted successfuly");
}

///Sorting Data with ID
void sortEmployee()
{

}




