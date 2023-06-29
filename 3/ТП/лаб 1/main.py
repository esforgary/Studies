# Бинарный алгоритм
array = [-10, 2, 12, 34, -36, 45, 8, 0, 90, 100]
desired_value = 2
first, last, mid, index = 0, len(array) - 1, 0, 0
array = sorted(array)
print(array)
while (first <= last) and (array[index] != desired_value):
    mid = int((first + last) // 2)
    if array[mid] == desired_value:
        index = mid
    else:
        if desired_value < array[mid]:
            last = mid - 1
        else:
            first = mid + 1
if desired_value != array[index]:
        index = '0'
res = index
print(f"Искомое значение ({desired_value}) находится под индексом {res}.\n")