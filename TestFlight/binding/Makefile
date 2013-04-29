BTOUCH=/Developer/MonoTouch/usr/bin/btouch
VERSION=1.2.4
all: TestFlight.dll

TestFlightSDK$(VERSION).zip:
	@echo "You'll need to obtain a copy of TestFlightSDK$(VERSION).zip"
	@echo "from https://testflightapp.com/sdk/download"
	@echo
	@open https://testflightapp.com/sdk/download
	exit 1

libTestFlight.a: TestFlightSDK$(VERSION).zip
	unzip -p $^ $@ > $@

TestFlight.dll: Makefile AssemblyInfo.cs StructsAndEnums.cs testflight.cs testflight-threadsafe.cs testflight-cplusplus.cs extras.cs libTestFlight.a
	$(BTOUCH) -e testflight.cs AssemblyInfo.cs -s:StructsAndEnums.cs -x:testflight-threadsafe.cs -x:testflight-cplusplus.cs -x:extras.cs --out=$@ --link-with=libTestFlight.a,libTestFlight.a

clean:
	-rm -f *.a *.dll
