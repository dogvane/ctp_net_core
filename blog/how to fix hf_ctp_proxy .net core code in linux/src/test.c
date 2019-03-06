#include <stdio.h>
#include <string.h>

extern "C" void* fun1()
{
	printf("fun1\n");
}


extern "C" void* fun_input_int(int i)
{
	printf("fun_input_int %d\n", i);
}

extern "C" void* fun_input_long(long i)
{
	printf("fun_input_long %ld\n", i);
}

extern "C" void* fun_input_float(float i)
{
	printf("fun_input_float %f\n", i);
}

extern "C" void* fun_input_double(double i)
{
	printf("fun_input_double %lf\n", i);
}

struct s1
{
	int i;
	long l;
	float f;
	double d;
};

extern "C" void* fun_input_struct_s1(s1* s)
{
	printf("fun_input_struct size: %d\n", sizeof(s1));
	printf("fun_input_struct int %d\n", s->i);
	printf("fun_input_struct long %ld\n", s->l);
	printf("fun_input_struct float %f\n", s->f);
	printf("fun_input_struct double %lf\n", s->d);
}

typedef char TUserName[31];
typedef char TErrorMsg[81];

// 以下是字符串测试
extern "C" void* fun_input_char_username(TUserName username)
{
	printf("fun_input_char_username %s\n", username);
}

extern "C" void* fun_input_char_username2(TUserName username, TUserName username2)
{
	printf("fun_input_char_username 1 %s\n", username);
	printf("fun_input_char_username 2 %s\n", username2);
}

struct s_string_1
{
	TUserName username;
	TUserName password;
	int logintype;
};

struct s_string_3
{
	TUserName username;
	TUserName password;
	int logintype;
};

struct s_error_ret
{
	int ErrorId;
	TErrorMsg ErrorMsg;
};

extern "C" void* fun_input_char_login(s_string_1* s1)
{
	printf("fun_input_char_login size %d\n", sizeof(s_string_1));
	printf("fun_input_char_login username %s\n", s1->username);
	printf("fun_input_char_login password %s\n", s1->password);
	printf("fun_input_char_login logintype %d\n", s1->logintype);
}

typedef int(*RspQryCombAction)(s_error_ret *pCombAction);
void * call_back_fun = NULL;


extern "C" void* set_call_back_fun(RspQryCombAction* fun)
{
	if (fun != NULL)
	{
		printf("fun point %d \n", fun);
		call_back_fun = fun;
	}
	else {
		printf("fun is null");
	}
}

extern "C" void* test_call_back_fun(int strLen, char* msg)
{
	printf("strlen %d pointer %d \n", strLen, msg);

	for (int i = 0; i < strLen; i++) {
		printf("%d ", msg[i]);
	}
	printf("\n");

	s_error_ret ret;
	ret.ErrorId = -1;
	memcpy(ret.ErrorMsg, msg, strLen);
	// memset(ret.ErrorMsg, 0, 81);

	if (call_back_fun != NULL)
		((RspQryCombAction)call_back_fun)(&ret);
}