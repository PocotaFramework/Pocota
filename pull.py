import os
import tempfile
import sys

fp = tempfile.NamedTemporaryFile()
fp.close();

directory = os.path.dirname(os.path.realpath(__file__))

os.chdir(directory)
os.system('git rev-parse --abbrev-ref HEAD > {}'.format(fp.name))
f = open(fp.name)

for line in f:
    branch = line.strip()
    break
f.close()

print(branch)

os.system('git remote > {}'.format(fp.name))
f = open(fp.name)

for line in f:
	if 'github' in line:
		remote = line.split()[0]
		break
f.close()

os.system('git pull {} {}'.format(remote, branch))

