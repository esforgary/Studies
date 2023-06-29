package main

import (
	"fmt"
	"math/rand"
)

func quickSort(nums []int) []int {
	if len(nums) <= 1 {
		return nums
	}

	q := nums[rand.Intn(len(nums))]

	var l_nums, b_nums []int
	var e_nums = make([]int, 0, len(nums))
	for _, n := range nums {
		switch {
		case n < q:
			l_nums = append(l_nums, n)
		case n > q:
			b_nums = append(b_nums, n)
		default:
			e_nums = append(e_nums, q)
		}
	}

	return append(append(quickSort(l_nums), e_nums...), quickSort(b_nums)...)
}

func binaryAlgorithm(array []int, desiredValue int) int {
	first, last, mid, index := 0, len(array)-1, 0, 0

	for first <= last && array[index] != desiredValue {
		mid = (first + last) / 2
		if array[mid] == desiredValue {
			index = mid
		} else {
			if desiredValue < array[mid] {
				last = mid - 1
			} else {
				first = mid + 1
			}
		}
	}

	if desiredValue != array[index] {
		return -1
	}

	return index
}

func main() {
	var array = make([]int, 100)
	for i := 0; i < len(array); i++ {
		array[i] = rand.Intn(201) - 100
	}
	array = quickSort(array)
	fmt.Println(array)

	var desiredValue int
	fmt.Print("Введите число, которое нужно найти: ")
	_, err := fmt.Scanf("%d", &desiredValue)
	if err != nil {
		fmt.Println("\nНеверные данные !!!\n")
		return
	}

	res := binaryAlgorithm(array, desiredValue)

	if res == -1 {
		fmt.Printf("\n%d не является элементом данного массива.\n", desiredValue)
	} else {
		fmt.Printf("Искомое значение (%d) находится под индексом %d.\n", desiredValue, res)
	}
}
