// Utilities.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <cstdlib>

#include "UglyNumber.h"
using namespace std;

void TestUglyNumber()
{
	string strNum;
	cout<<"please input a number:"<<endl;
	cin >> strNum;
	char* ptr;
	long num;
	while(strNum != "q")
	{
		num = strtol(strNum.c_str(),&ptr,10);
		bool ret = UglyNumber::IsUglyNum(num);
		if (ret)
		{
			cout<<"true"<<endl;
		}
		else
		{
			cout<<"false"<<endl;
		}
		cout<<"please input a number:"<<endl;
		cin >> strNum;
	}
	delete ptr;
	ptr=nullptr;
}

void TestFindNthUglyNum()
{
	string strNum;
	cout<<"please input a number:"<<endl;
	cin >> strNum;
	char* ptr;
	long num;
	while(strNum != "q")
	{
		num = strtol(strNum.c_str(),&ptr,10);
		long ret = UglyNumber::FindNthUglyNum(num);
		cout<<ret<<endl;
		cout<<"please input a number:"<<endl;
		cin >> strNum;
	}
	delete ptr;
	ptr=nullptr;
}

int _tmain(int argc, _TCHAR* argv[])
{
	//TestUglyNumber();
	//TestFindNthUglyNum();
	UglyNumber* un = new UglyNumber(1536);
	un->Resolve();
	std::string str=un->GetFactorStr(" X ");
	getchar();
	return 0;
}

