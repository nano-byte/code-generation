#!/bin/sh
set -e
cd `dirname $0`

../0install.sh run https://apps.0install.net/dotnet/docfx.xml --loglevel=warning --warningsAsErrors docfx.json
