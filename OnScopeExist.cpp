// OnScopeExist.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
using namespace std;

#define FORBID_COPY_AND_ASSIGN(TypeName)		\
private:										\
	TypeName(const TypeName&);					\
	TypeName& operator=(const TypeName&)


#define FORBID_ALLOC_ON_HEAP					\
private:										\
	static void *operator new (size_t size);	\
	static void operator delete (void *ptr);	\
	static void *operator new[] (size_t size);	\
	static void operator delete[] (void *ptr)

template<typename Func>
class ScopeGuard
{
public:
	ScopeGuard(Func func) : m_func(func) {}
	~ScopeGuard() { m_func(); }
	ScopeGuard(ScopeGuard&& rhs) { Move(std::move(rhs)); }
	ScopeGuard&	operator=(ScopeGuard&& rhs) { Move(std::move(rhs)); return *this; }

private:
	Func m_func;
	void Move(ScopeGuard&& rhs) { m_func = rhs.m_func; rhs.m_func = DoNothing; }
	void DoNothing(){}

	FORBID_COPY_AND_ASSIGN(ScopeGuard<Func>);
	FORBID_ALLOC_ON_HEAP;
};

template<typename Func>
ScopeGuard<Func> MakeScopeGuardObj(Func func)
{
	return ScopeGuard<Func>(func);
};

#define MAKE_LOCAL_VAR_NAME(arg1, arg2) DO_STRING_CAT(arg1, arg2)
#define DO_STRING_CAT(arg1, arg2) arg1 ## arg2
#define TEMP_LAMDA_TYPE_NAME MAKE_LOCAL_VAR_NAME(scope_guard_type_, __LINE__)
#define ON_SCOPE_EXIT(code) \
	auto TEMP_LAMDA_TYPE_NAME = [&](){code;}; ScopeGuard<decltype(TEMP_LAMDA_TYPE_NAME)> MAKE_LOCAL_VAR_NAME(scope_guard_, __LINE__)(TEMP_LAMDA_TYPE_NAME)

void Add1(int& ii)
{
	ii++;
	ON_SCOPE_EXIT(
		ii--;
		ii--;
	);
	ii++;
}

int _tmain(int argc, _TCHAR* argv[])
{
	int ii = 0;
	Add1(ii);
	cout<<ii<<endl;
	getchar();
	return 0;
}




