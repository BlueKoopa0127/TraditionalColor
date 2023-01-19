import csv
import json
import os
dir = os.getcwd()
print(dir)
# JSONファイルのロード
with open(dir + '/colorall12.json', 'r') as f:
    json_dict = json.load(f)

# CSVファイルに書き込み
with open('test.csv', 'w', newline='') as f:
    writer = csv.DictWriter(f, fieldnames=json_dict[0].keys(), 
                            doublequote=True, 
                            quoting=csv.QUOTE_ALL)
    writer.writeheader()
    writer.writerows(json_dict)