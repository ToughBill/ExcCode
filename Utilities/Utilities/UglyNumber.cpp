#include "stdafx.h"
#include "UglyNumber.h"
#include <string>
#include <sstream>


bool UglyNumber::Resolve()
{
	if (!UglyNumber::IsUglyNum(m_num))
	{
		return false;
	}
	long temp = m_num;
	std::vector<long> factors;
	while(temp % 2 == 0)
	{
		factors.push_back(2);
		temp /= 2;
	}
	while(temp % 3 == 0)
	{
		factors.push_back(3);
		temp /= 3;
	}
	while(temp % 5 == 0)
	{
		factors.push_back(5);
		temp /= 5;
	}

	if (temp == 1)
	{
		m_factors.assign(factors.begin(),factors.end());
	}
	else
	{
		return false;
	}
	return true;
}

std::string UglyNumber::GetFactorStr(std::string seperator/* = 'X'*/)
{
	std::stringstream s;
	for (auto iter = m_factors.begin(); iter != m_factors.end(); iter++)
	{
		s<<*iter<<seperator;
	}
	return s.str().substr(0, s.str().size()-seperator.size());
}

bool UglyNumber::IsUglyNum(long num)
{
	if (num	<= 0)
	{
		return false;
	}
	long temp = num;
	temp = Div(temp, 2);
	temp = Div(temp, 3);
	temp = Div(temp, 5);

	return temp == 1;
}
long UglyNumber::Div(long dividend, long divisor)
{
	while(dividend % divisor == 0)
	{
		dividend /= divisor;
	}

	return dividend;
}

long UglyNumber::FindNthUglyNum(long nth)
{
	if (nth <= 0)
	{
		return -1;
	}

	std::vector<long> numbs;
	numbs.resize(nth);
	long n2 = 1;
	long n3 = 1;
	long n5 = 1;
	numbs[0] = 1;
	for (long i = 1; i < nth; i++)
	{
		long prev = numbs[i-1];

		while(numbs[n2-1]*2 <= prev){ n2++; }
		while(numbs[n3-1]*3 <= prev){ n3++; }
		while(numbs[n5-1]*5 <= prev){ n5++; }

		long temp2 = numbs[n2-1]*2;
		long temp3 = numbs[n3-1]*3;
		long temp5 = numbs[n5-1]*5;
		long minNum = std::min(temp2, std::min(temp3,temp5));
		
		numbs[i] = minNum;
	}
	return numbs.back();
}