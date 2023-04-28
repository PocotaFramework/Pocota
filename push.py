import os
import tempfile

os.chdir('../MaterialDesignInXamlToolkit')
fp = tempfile.NamedTemporaryFile()
fp.close();
os.system('git diff --name-only > {}'.format(fp.name))
f = open(fp.name)
print(f.read())
