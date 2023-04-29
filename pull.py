import os
import tempfile
import sys

directory = os.path.dirname(os.path.realpath(__file__))
source = '{}\Pocota\PocotaCSharpClientPocoBrowser\ChangedMaterial'.format(directory)
print(source)

fp = tempfile.NamedTemporaryFile()
fp.close();
os.system('dir /s /b {} > {}'.format(source, fp.name))
f = open(fp.name)

for line in f:
	path = line.strip()
	if os.path.isfile(path):
		destination = '{}\..\MaterialDesignInXamlToolkit\{}'.format(directory, path[len(source):])
		print(path, destination)
