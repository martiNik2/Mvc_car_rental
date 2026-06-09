FROM python:3.12-trixie

WORKDIR /Front_end


COPY requirements.txt .

RUN pip install --no-cache-dir -r requirements.txt


COPY . .

CMD ["python3","-m","http.server"]
EXPOSE 8000
