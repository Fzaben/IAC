include ../.env
ANSIBLE_CONFIG=/work/ansible/ansible.cfg
ANSIBLE_FORCE_COLOR=false

export

ping:
	- ansible linux -m ping

list:
	- ansible linux -a 'ls -la /home/do'

check-inventory:
	- ansible-inventory --list --yaml

play:
	- ansible-playbook playbooks/nginx.yml

%:  %-default
	- @  true
