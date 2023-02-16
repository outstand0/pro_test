# This Makefile will build the MinGW Win32 application.

HEADERS = include/callbacks.h include/resource.h
OBJS =	obj/winmain.o obj/callbacks.o obj/resource.o obj/diag.o obj/normal.o
INCLUDE_DIRS = -I.\include

WARNS = -Wall

CC = gcc
LDFLAGS = -s -lcomctl32 -lGdi32 -Wl,--subsystem,windows
RC = windres

# Compile ANSI build only if CHARSET=ANSI
ifeq (${CHARSET}, ANSI)
  CFLAGS = -O3 -std=c99 -D _WIN32_IE=0x0A00 -D WINVER=0xA00 ${WARNS}
else
  CFLAGS = -O3 -std=c99 -D UNICODE -D _UNICODE -D _WIN32_IE=0x0A00 -D WINVER=0xA00 ${WARNS}
endif


all: TM05_Earbud_BD_Checker.exe

TM05_Earbud_BD_Checker.exe: ${OBJS}
	${CC} -o "$@" ${OBJS} ${LDFLAGS}

clean:
	del obj\*.o "TM05_Earbud_BD_Checker.exe"

obj:
	mkdir obj

obj/%.o: src/%.c ${HEADERS} obj
	${CC} ${CFLAGS} ${INCLUDE_DIRS} -c $< -o $@

obj/resource.o: res/resource.rc res/Application.manifest res/Application.ico include/resource.h
	${RC} -I.\include -I.\res -i $< -o $@