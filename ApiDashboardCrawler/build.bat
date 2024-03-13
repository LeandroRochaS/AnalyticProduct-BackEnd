(Get-ECRLoginCommand).Password | docker login --username AWS --password-stdin 671233729995.dkr.ecr.us-east-1.amazonaws.com
docker build -t dashboard .
docker tag dashboard:latest 671233729995.dkr.ecr.us-east-1.amazonaws.com/dashboard:latest
docker push 671233729995.dkr.ecr.us-east-1.amazonaws.com/dashboard:latest