#include <vector>
#include <string>

class UglyNumber
{
public:
	UglyNumber(long num):m_num(num){}
	bool Resolve();
	std::vector<long> GetFactors() {return m_factors;}
	std::string GetFactorStr(std::string seperator = "X");

	static bool IsUglyNum(long num);
	static long FindNthUglyNum(long nth);

private:
	long m_num;
	std::vector<long> m_factors;

	static long Div(long dividend, long divisor);

};