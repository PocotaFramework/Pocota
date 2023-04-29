import os
import tempfile
import sys

directory = os.path.dirname(os.path.realpath(__file__))
os.chdir('{}\..\MaterialDesignInXamlToolkit'.format(directory))
fp = tempfile.NamedTemporaryFile()
fp.close();
os.system('git diff --name-only > {}'.format(fp.name))
f = open(fp.name)
for line in f:
    command = 'xcopy /s /y {0} {1}\Pocota\PocotaCSharpClientPocoBrowser\ChangedMaterial\{0}'.format(line.strip().replace('/', '\\'), directory)
    os.system(command)
f.close()

os.chdir(directory)
os.system('git status --porcelain > {}'.format(fp.name))
f.close()
f = open(fp.name)
untracked = []
for line in f:
    if ord(line[0]) == 63 and ord(line[1]) == 63:
        untracked.append(line[2:].strip())
if len(untracked) > 0:
    print('Manage untracked files and run again:')
    for line in untracked:
        print('    {}'.format(line));
    sys.exit(0)

f.close()

os.system('git commit --allow-empty-message -m="" -a')

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
    os.system('git push {} {}'.format(line, branch))

f.close()
