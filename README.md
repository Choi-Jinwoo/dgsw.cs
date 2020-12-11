# C#

`이것이 C#이다`책 기반.
오타, 피드백 `issue, PullRequest`로 남겨주세요

## 접근 한정자



| 접근한정자         | 설명                                                         |
| :----------------- | ------------------------------------------------------------ |
| public             | 클래스의 내부/외부 모든 곳에서 접근할 수 있습니다.           |
| protected          | 클래스의 외부에서는 접근할 수 없지만, 파생 클래스에서는 접근이 가능합니다. |
| private            | 클래스의 내부에서만 접근할 수 있습니다. 파생 클래스에서도 접근이 불가능합니다. |
| internal           | 같은 어셈블리에 있는 코드에서만 public으로 접근할 수 있습니다. 다른 어셈블리에 있는 코드에서는 private와 같은 수준의 접근성을 가집니다. |
| protected internal | 같은 어셈블리에 있는 코드에서만 protected로 접근할 수 있습니다. 다른 어셈블리에 있는 코드에서는 private와 같은 수준의 접근성을 가집니다. |
| private protected  | 같은 어셈블리에 있는 클래스에서 상속받은 클래스 내부에서만 접근이 가능합니다. |

접근 한정자로 수식하지 않은 클래스의 멤버는 무조건 `private` 로 접근 수준이 자동으로 지정됨





## 형변환

| 연산자 | 설명                                                         |
| ------ | ------------------------------------------------------------ |
| is     | 객체가 해당 형식에 해당하는지를 검사하여 그 결과를 bool 값으로 반환합니다. |
| as     | 형식 변환 연산자와 같은 역할을 합니다. 다만 형변환 연산자가 변환에 실패하는 경우 예외를 던지는 반면에 as 연산자는 객체 참조를 null로 만든다는 것이 다릅니다. |

```c#
class Mammal {}
class Dog: Mammal {}

Mammal mammal = new Dog();
if (mammal is Dog) // true
{
  // 동작
}

Dog dog = (Dog)mammal; // 변환 실패 시 예외를 던짐
Dog dog1 = mammal as Dog; // dog1은 null
```





## 구조체

### 클래스와 구조체의 차이

| 특징              | 클래스                          | 구조체                                                       |
| ----------------- | ------------------------------- | ------------------------------------------------------------ |
| __키워드__        | class                           | struct                                                       |
| __형식__          | 참조 형식                       | 값 형식                                                      |
| __복사__          | 얕은 복사 (`Shallow Copy`)      | 깊은 복사 (`Deep Copy`)                                      |
| __인스턴스 생성__ | new 연산자와 생성자 필요        | 선언만으로도 생성                                            |
| __생성자__        | 매개 변수 없는 생성자 선언 가능 | 매개 변수 없는 생성자 선언 불가능                            |
| __상속__          | 가능                            | 모든 구조체는 `System.Object` 형식을 상속하는 `System.Value`으로부터 직접 상속받음 |





## 클래스, 인터페이스, 추상 클래스

- 인터페이스, 추상 클래스의 파생 클래스에서는 __구현__해야됨
- 추상 클래스는 인터페이스와 달리 __구현__을 가질 수 있음
- 추상 클래스는 클래스와 달리 __인스턴스__를 가질 수 없음
- 추상 클래스의 추상 메소드는 파생 클래스에서 반드시 구현 해야하는 __강제성__이 있음(인터페이스와의 유사점)





## 컬렉션(Collection)

#### 1. ArrayList

- 배열과 유사하지만 컬렉션을 생성할 때 용량을 미리 지정하지 않아도 필요에 따라 용량이 자동으로 변함

- `Add` 메소드는 컬렉션의 마지막에 있는 요소에 새 요소를 추가

- `RemoveAt` 메소드는 특정 인덱스에 있는 요소를 제거

- `Insert` 메소드는 원하는 위치에 새 요소를 삽입

  ```c#
  ArrayList list = new ArrayList();
  list.Add(1); // [1]
  list.Add(2); // [1, 2]
  list.Add(3); // [1, 2, 3]
  list.RemoveAt(1); // [1, 3]
  list.Insert(1, 4); // [1, 4, 5]
  ```



#### 2. Queue

- `Enqueue` 메소드는 통해 데이터를 뒤에 추가
- `Dequeue` 메소드는 가장 앞의 데이터를 삭제



#### 3. Stack

- `LIFO` 구조의 컬렉션
- `Push` 메소드를 이용하여 데이터를 위에 쌓음
- `Pop` 메소드를 이용하여 위에 샇인 데이터를 꺼냄



#### 4. HashTable

- `Key`, `Value`의 쌍으로 이루어진 데이터를 구조

  ```c#
  HashTable ht = new HashTable();
  ht["book"] = "책";
  
  Console.WriteLine(ht["book"]);
  ```





## 대리자

#### 선언 방식

```c#
한정자 delegate 반환 형식 대리자 이름 (매개변수 목록);

public delegate int MyDelegate(int a, int b);
```



__연습문제 1__

```c#
delegate int MyDelegate(int a, int b);

class Program
{
  static void Main(string[] args)
  {
    MyDelegate Callback;

    Callback = ((int a, int b) =>
    {
	    return a + b;
    });

    Console.WriteLine(Callback(3, 4));

    Callback = ((int a, int b) =>
    {
  	  return a - b;
    });
    Console.WriteLine(Callback(7, 5));
  }
}

```



__연습문제 2__

```c#
delegate void MyDelegate(int a);

class Market
{
  public event MyDelegate CustomerEvent;

  public void BuySomething(int CustomerNo)
  { 
    if (CustomerNo == 30)
    {
	    CustomerEvent(CustomerNo);
    }
	}
}

class Program
{
  static void Main(string[] args)
  {
    Market market = new Market();
    market.CustomerEvent += new MyDelegate((int a) =>
    {
    	Console.WriteLine($"축하합니다. {a}번째 고객 이벤트에 당첨되셨습니다.");
    });

    for (int customerNo = 0; customerNo < 100; customerNo += 10)
    {
    	market.BuySomething(customerNo);
    }
  }
}
```





## LINQ

#### 1. from

쿼리식의 대상이 될 데이터 원본과 데이터 원본 안에 들어 있는 각 요소 데이터를 나타내는 범위 변수를 `from` 절에서 지정함



#### 2. where

뽑아낸 범위 변수가 가져야할 조건을 `where` 연산자에 매개 변수로 입력하면 해당 조건에 부합하는 데이터만 걸러냄



#### 3. orderby

데이터를 정렬하는 연산자.  매개변수로는 정렬의 기준이 될 항목을 입력함. 기본적으로는 오름차순으로 정렬함

`orderby ~ ascending`, `orderby ~ descending`을 통해 오름차순, 내림차순을 지정할 수 있음



#### 4. select

최종 결과를 추출하는 연산자. 매개 변수로 추출할 항목을 입력함.



```c#
var profiles = from profile in arrProfile
  						 where profile.Height < 175
							 orderby profile.Height descending
							 select profile.Height
```





## 열거형(Enum)

```c#
enum DialogResult
{
	YES,     // 0
	NO,      // 1
	CANCEL,  // 2
	CONFIRM, // 3
}

-----------------------

enum DialogResult
{
	YES = 1,  // 1
	NO,       // 2
	CANCEL,   // 3
	CONFIRM,  // 4
}

-----------------------

enum DialogResult
{
	YES = 1,      // 1
	NO,           // 2
	CANCEL = 10,  // 10
	CONFIRM,      // 11
}

// 사용 시
Console.WriteLine((int)DialogResult.YES); // 마지막 Enum을 기준으로 1
```





## 자료형(94페이지 연습문제 1)

```c#
// 문제
int a = 7.3; // 오류
float b = 3.14; // 오류
double c = a * b;
char d = "abc"; // 오류
string e = '한'; // 오류

// 해설
int a = 7;
float b = 3.14f; // float 형식은 뒤에 f를 붙임
string d = "abc";
char e = '한'

```





## Nullable, Null 병합 연산자

#### nullable

```c#
int a = null; // 오류
int? a = null;
```



#### null 병합 연산자 '??'

```c#
int? a = null;
Console.WriteLine($"{a ?? 0}"); // a가 null이기 때문에 0이 출력

a = 99;
Console.WriteLine($"{a ?? 0}"); // a가 null이 아니기 때문에 99가 출력
```





## 증가 연산자, 감소 연산자

```c#
int a = 1;
Console.WriteLine(a++); // 1이 출력되고 a의 값이 1증가
// a의 값은 2
Console.WriteLine(++a); // a의 값이 1증가 되고 출력, 3이 출력
```





## 참조에 의한 매개 변수 전달

#### ref

```c#
static void Main(string[] args)
{
  int a = 1;
  int b = 2;

  Swap(ref a, ref b);

  Console.WriteLine(a);
  Console.WriteLine(b);
}

static void Swap(ref int a, ref int b)
{
  int temp = b;
  b = a;
  a = temp;
}
```

`ref`를 통해 원본 변수를 수정



##### 참조 반환값

```c#
class SomeClass
{
  public int SomeValue = 0;

  public ref int SomeMethod()
  {
  	return ref SomeValue;
  }
}

class Program
{
  static void Main(string[] args)
  {
    SomeClass obj = new SomeClass();
    int result =  obj.SomeMethod();
    result = 10; // 참조하지 않은 값을 변경
    Console.WriteLine(obj.SomeValue); // 0

    ref int refResult = ref obj.SomeMethod();
    refResult = 10; // 참조한 값을 변경
    Console.WriteLine(obj.SomeValue); // 10
  }
}

```





#### out(출력 전용 매개 변수)

```c#
static void Main(string[] args)
{
  int a = 20;
  int b = 3;
  int c;
  int d;

  Divide(a, b, out c, out d);

  Console.WriteLine(c);
  Console.WriteLine(d);
}

static void Divide(int a, int b, out int quotient, out int remainder)
{
  quotient = a / b; // out은 할당해주지 않으면 컴파일 오류가 발생
  remainder = a % b;
}

```

`out`은 `ref`와 같이 참조에 의한 매개변수지만 할당 해주지 않으면 컴파일 오류가 남





## 얕은 복사, 깊은 복사

```c#
class MyClass
{
  public int MyField1;
  public int MyField2;

  public MyClass DeepCopy()
  {
    MyClass newCopy = new MyClass();
    newCopy.MyField1 = this.MyField1;
    newCopy.MyField2 = this.MyField2;

    return newCopy;
  }
}

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Shallow Copy");
    // 해당 중괄호는 변수의 스코프를 지정하기 위한 중괄호
    { 
      MyClass source = new MyClass();
      source.MyField1 = 10;
      source.MyField2 = 20;

      MyClass target = source;
      target.MyField2 = 30;

      Console.WriteLine($"{source.MyField1}, {source.MyField2}");
      Console.WriteLine($"{target.MyField1}, {target.MyField2}");
    }


    Console.WriteLine("Deep Copy");
    // 해당 중괄호는 변수의 스코프를 지정하기 위한 중괄호
    { 
      MyClass source = new MyClass();
      source.MyField1 = 10;
      source.MyField2 = 20;

      MyClass target = source.DeepCopy();
      target.MyField2 = 30;

      Console.WriteLine($"{source.MyField1}, {source.MyField2}");
      Console.WriteLine($"{target.MyField1}, {target.MyField2}");
    }
  }
}

```

#### 결과

````c#
Shallow Copy
10, 30
10, 30
Deep Copy
10, 20
10, 30
````





## 배열을 초기화 하는 방법

#### 1번 방법

```c#
string[] array1 = new string[3] { "안녕", "hello", "halo" };
```



#### 2번 방법

```c#
string[] array2 = new string[] { "안녕", "hello", "halo" }; // 1번과 달리 용량을 생략
```



#### 3번 방법

```c#
string[] array3 =  { "안녕", "hello", "halo" };
```





## 소멸자

#### 파생 클래스의 생성 과정

1. 기반 클래스의 생성자를 호출
2. 파생 클래스의 생성자를 호출



#### 파생 클래스의 소멸 과정

1. 파생 클래스의 종료자를 호출
2. 기반 클래스의 종료자를 호출



```c#
class Base
{ 
  public Base()
  {
  	Console.WriteLine("Base()");
  }

  ~Base()
  {
 	 Console.WriteLine("~Base()");
  }
}

class Derived : Base
{ 
  public Derived()
  {
  	Console.WriteLine("Derived()");
  }

  ~Derived()
  {
  	Console.WriteLine("~Derived()");
  }
}

class Program
{
	static void Main(string[] args)
  {
		Derived derived = new Derived();
  }
}

```

#### 결과

````
* 이론적인 결과, 실습해보니 나는 안됨

Base()
Derived()
~Derived()
~Base()
````





## 날짜 및 시간 서식화

| 서식 지정자 | 대상 서식  | 설명                                                         |
| ----------- | ---------- | ------------------------------------------------------------ |
| y           | 연도       | - yy: 두 자릿수 연도(2019 > 19)<br />- yyyy: 네 자릿수 연도(2019 > 2019) |
| M           | 월         | - M: 한 자릿수 월(2019-01 > 1)<br />- MM: 두 자릿수 월(2019-01 > 01) |
| d           | 일         | - d: 한 자릿수 일(2019-01-01 > 1)<br />-dd: 두 자릿수 일(2019-01-01 > 01) |
| h           | 시(1 ~ 12) | - h: 한 자릿수 시(2019-01-01 09 > 9)<br />- hh: 두 자릿수 시(2019-01-01 09 > 09) |
| H           | 시(1 ~ 23) | - H: 한 자릿수 시(2019-01-01 21 > 21)<br />- HH: 두 자릿수 시(2019-01-01 21 > 21) |
| m           | 분         | - m: 한 자릿수 분(2019-01-01 01:01 > 1)<br />- mm: 두 자릿수 분(2019-01-01 01:01 > 01) |
| s           | 초         | - s: 한 자릿수 초(2019-01-01 01:01:01 > 1)<br />- ss: 두 자릿수 초(2019-01-01 01:01:01 > 01) |
| tt          | 오전/오후  | - tt: 오전/오후<br />- (2019-01-01 11:00:00 > 오전)<br />- (2019-01-01 23:00:00 > 오후) |
| ddd         | 요일       | - ddd: 약식 요일(2019-01-01 01:00:00 > 토)<br />- dddd: 전체 요일(2019-01-01 01:00:00 > 토요일) |

```c#
static void Main(string[] args)
{
  DateTime dt = new DateTime(2018, 11, 3, 23, 18, 22);

  Console.WriteLine("12시간 형식: {0:yyyy-MM-dd tt hh:mm:ss (ddd)}", dt);
  Console.WriteLine("24시간 형식: {0:yyyy-MM-dd HH:mm:ss (dddd)}", dt);
}

// 결과
// 12시간 형식: 2018-11-03 PM 11:18:22 (Sat)
// 24시간 형식: 2018-11-03 23:18:22 (Saturday)
```



#### CultureInfo

```c#
static void Main(string[] args)
{
  DateTime dt = new DateTime(2018, 11, 3, 23, 18, 22);

  CultureInfo ciKo = new CultureInfo("ko-KR");
  Console.WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciKo));

  CultureInfo ciEn = new CultureInfo("en-US");
  Console.WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciEn));
}

// 결과
// 2018-11-03 오후 11:18:22 (토)
// 2018-11-03 PM 11:18:22 (Sat)
```



__추가 예제__

```c#
static void Main(string[] args)
{
  DateTime dt = new DateTime(2018, 11, 3, 23, 18, 22);

  Console.WriteLine("12시간 형식: {0:yyyy-MM-dd tt hh:mm:ss (ddd)}", dt);
  Console.WriteLine("24시간 형식: {0:yyyy-MM-dd HH:mm:ss (dddd)}", dt);

  CultureInfo ciKo = new CultureInfo("ko-KR");
  Console.WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciKo));
  Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciKo));
  Console.WriteLine(dt.ToString(ciKo));

  CultureInfo ciEn = new CultureInfo("en-US");
  Console.WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciEn));
  Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciEn));
  Console.WriteLine(dt.ToString(ciEn));
}

// 결과
// 12시간 형식: 2018-11-03 PM 11:18:22 (Sat)
// 24시간 형식: 2018-11-03 23:18:22 (Saturday)
//
// 2018-11-03 오후 11:18:22 (토)
// 2018-11-03 23:18:22 (토요일)
// 2018. 11. 3. 오후 11:18:22
//
// 2018-11-03 PM 11:18:22 (Sat)
// 2018-11-03 23:18:22 (Saturday)
// 11/3/2018 11:18:22 PM
```





## 오버로딩

매개변수의 수와 형식을 분석(__반환 형식은 아님__)하여 메서드를 호출



#### 가변길이 매개 변수

`params` 키워드와 배열을 통해 선언

```c#
static void Main(string[] args)
{
  int sum = Sum(1, 2, 3, 4);
  Console.WriteLine(sum);
}


static int Sum(params int[] args)
{
  int sum = 0;

  for (int i = 0; i < args.Length; i += 1)
  {
	  sum += args[i];
  }

  return sum;
}
```



#### 선택적 매개 변수

__반드시 뒤에서 부터 값을 초기화__

```c#
static void Main(string[] args)
{
  int result1 = MyMethod(1, 2);
  Console.WriteLine(result1);

  int result2 = MyMethod(1, 2, 3);
  Console.WriteLine(result2);
}


static int MyMethod(int a, int b, int c = 1)
{
	return a + b + c;
}

static int MyMethod2(int a = 1, int b, int c) // 컴파일 오류(앞에서 부터 초기화함)
{
	return a + b + c;
}
```





## 봉인 클래스

봉인 클래스(종단 클래스)는 `sealed` 한정자를 통해 생성 가능. 

__상속 봉인__ 되어 파생 클래스를 만들지 못함

```c#
sealed class A { }
class B : A { } // 컴파일 오류
```





## 분할 클래스

분할 클래스는 여러 번에 나눠서 구현한 클래스. 클래스의 구현이 길어질 경우 여러 파일에 나눠서 구현



```c#
// A.cs
partial class MyClass
{
	public void Method1();
}

// B.cs
partial class MyClass
{
	public void Method2();
}

// main
MyClass obj = new MyClass();
obj.Method1();
obj.Method2();
```







copyrightⓒ2020 최진우 All rights reserved. 
