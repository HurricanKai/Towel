﻿using System;
using static Towel.Syntax;

namespace Towel.Algorithms
{
	/// <summary>Contains static sorting algorithms.</summary>
	public static class Sort
	{
		#region Bubble

		/// <summary>Sorts values using the bubble sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Bubble<T>(T[] array) =>
			Bubble(array, Compare.Default);

		/// <summary>Sorts values using the bubble sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Bubble<T>(T[] array, Compare<T> compare) =>
			Bubble(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the bubble sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Bubble<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Bubble(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the bubble sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Bubble<T>(T[] array, int start, int end, Compare<T> compare) =>
			Bubble<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the bubble sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		public static void Bubble<T, Compare>(T[] array, int start, int end, Compare compare)
			where Compare : struct, ICompare<T> =>
			Bubble<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the bubble sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Bubble<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			Bubble<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set);

		/// <summary>Sorts values using the bubble sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Bubble<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			for (int i = start; i <= end; i++)
			{
				for (int j = start; j <= end - 1; j++)
				{
					if (compare.Do(get.Do(j), get.Do(j + 1)) == Greater)
					{
						T temp = get.Do(j + 1);
						set.Do(j + 1, get.Do(j));
						set.Do(j, temp);
					}
				}
			}
		}

		#endregion

		#region Selection

		/// <summary>Sorts values using the selection sort algoritm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">the array to be sorted</param>
		/// <runtime>Ω(n^2), ε(n^2), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Selection<T>(T[] array) =>
			Selection(array, Compare.Default);

		/// <summary>Sorts values using the selection sort algoritm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare delegate.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n^2), ε(n^2), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Selection<T>(T[] array, Compare<T> compare) =>
			Selection(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the selection sort algoritm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare delegate.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare delegate.</param>
		public static void Selection<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Selection(array, 0, array.Length - 1, compare);

		/// <summary>Sorts an array using the selection sort algoritm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare delegate.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n^2), ε(n^2), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Selection<T>(T[] array, int start, int end, Compare<T> compare) =>
			Selection<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the selection sort algoritm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare delegate.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare delegate.</param>
		public static void Selection<T, Compare>(T[] array, int start, int end, Compare compare)
			where Compare : struct, ICompare<T> =>
			Selection<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the selection sort algoritm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare delegate.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n^2), ε(n^2), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Selection<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			Selection<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set);

		/// <summary>Sorts values using the selection sort algoritm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare delegate.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare delegate.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <runtime>Ω(n^2), ε(n^2), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Selection<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			for (int i = start; i <= end; i++)
			{
				int min_idx = i;
				for (int j = i + 1; j <= end; j++)
				{
					if (compare.Do(get.Do(j), get.Do(min_idx)) == Less)
					{
						min_idx = j;
					}
				}
				T temp = get.Do(min_idx);
				set.Do(min_idx, get.Do(i));
				set.Do(i, temp);
			}
		}

		#endregion

		#region Insertion

		/// <summary>Sorts values using the insertion sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Insertion<T>(T[] array) =>
			Insertion(array, Compare.Default);

		/// <summary>Sorts values using the insertion sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Insertion<T>(T[] array, Compare<T> compare) =>
			Insertion(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the insertion sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Insertion<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Insertion(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the insertion sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">Returns positive if left greater than right.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Insertion<T>(T[] array, int start, int end, Compare<T> compare) =>
			Insertion<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the insertion sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Insertion<T, Compare>(T[] array, int start, int end, Compare compare)
			where Compare : struct, ICompare<T> =>
			Insertion<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the insertion sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">Returns positive if left greater than right.</param>
		/// <param name="get">Delegate for getting a value at a specified index.</param>
		/// <param name="set">Delegate for setting a value at a specified index.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Insertion<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			Insertion<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set);

		/// <summary>Sorts values using the insertion sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void Insertion<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			for (int i = start + 1; i <= end; i++)
			{
				T temp = get.Do(i);
				int j = i;
				for (; j > start && compare.Do(get.Do(j - 1), temp) == Greater; j--)
				{
					set.Do(j, get.Do(j - 1));
				}
				set.Do(j, temp);
			}
		}

		#endregion

		#region Quick

		/// <summary>Sorts values using the quick sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>ln(n)</memory>
		public static void Quick<T>(T[] array) =>
			Quick(array, Compare.Default);

		/// <summary>Sorts values using the quick sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>ln(n)</memory>
		public static void Quick<T>(T[] array, Compare<T> compare) =>
			Quick(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the quick sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>ln(n)</memory>
		public static void Quick<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Quick(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the quick sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>ln(n)</memory>
		public static void Quick<T>(T[] array, int start, int end, Compare<T> compare) =>
			Quick<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the quick sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>ln(n)</memory>
		public static void Quick<T, Compare>(T[] array, int start, int end, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Quick<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the quick sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">Delegate for setting a value at a specified index.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>ln(n)</memory>
		public static void Quick<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			Quick<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set);

		/// <summary>Sorts values using the quick sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>ln(n)</memory>
		public static void Quick<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T> =>
			Quick_Recursive<T, Compare, Get, Set>(start, end - start + 1, compare, get, set);

		internal static void Quick_Recursive<T, Compare, Get, Set>(int start, int len, Compare compare, Get get, Set set)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			if (len > 1)
			{
				T pivot = get.Do(start);
				int i = start;
				int j = start + len - 1;
				int k = j;
				while (i <= j)
				{
					if (compare.Do(get.Do(j), pivot) == Less)
					{
						T temp = get.Do(i);
						set.Do(i++, get.Do(j));
						set.Do(j, temp);
					}
					else if (compare.Do(get.Do(j), pivot) == Equal)
					{
						j--;
					}
					else
					{
						T temp = get.Do(k);
						set.Do(k--, get.Do(j));
						set.Do(j--, temp);
					}
				}
				Quick_Recursive<T, Compare, Get, Set>(start, i - start, compare, get, set);
				Quick_Recursive<T, Compare, Get, Set>(k + 1, start + len - (k + 1), compare, get, set);
			}
		}

		#endregion

		#region Merge

		/// <summary>Sorts values using the merge sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n*ln(n))</runtime>
		/// <stability>True</stability>
		/// <memory>Θ(n)</memory>
		public static void Merge<T>(T[] array) =>
			Merge(array, Compare.Default);

		/// <summary>Sorts values using the merge sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n*ln(n))</runtime>
		/// <stability>True</stability>
		/// <memory>Θ(n)</memory>
		public static void Merge<T>(T[] array, Compare<T> compare) =>
			Merge(array, 0, array.Length, compare);

		/// <summary>Sorts values using the merge sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n*ln(n))</runtime>
		/// <stability>True</stability>
		/// <memory>Θ(n)</memory>
		public static void Merge<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Merge(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the merge sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n*ln(n))</runtime>
		/// <stability>True</stability>
		/// <memory>Θ(n)</memory>
		public static void Merge<T>(T[] array, int start, int end, Compare<T> compare) =>
			Merge<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end - start, compare, array, array);

		/// <summary>Sorts values using the merge sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n*ln(n))</runtime>
		/// <stability>True</stability>
		/// <memory>Θ(n)</memory>
		public static void Merge<T, Compare>(T[] array, int start, int end, Compare compare)
			where Compare : struct, ICompare<T> =>
			Merge<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the merge sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">Delegate for getting a value at a specified index.</param>
		/// <param name="set">Delegate for setting a value at a specified index.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n*ln(n))</runtime>
		/// <stability>True</stability>
		/// <memory>Θ(n)</memory>
		public static void Merge<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			Merge<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end - start, compare, get, set);

		/// <summary>Sorts values using the merge sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n*ln(n))</runtime>
		/// <stability>True</stability>
		/// <memory>Θ(n)</memory>
		public static void Merge<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T> =>
			Merge_Recursive<T, Compare, Get, Set>(start, end, compare, get, set);

		internal static void Merge_Recursive<T, Compare, Get, Set>(int start, int len, Compare compare, Get get, Set set)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			if (len > 1)
			{
				int half = len / 2;
				Merge_Recursive<T, Compare, Get, Set>(start, half, compare, get, set);
				Merge_Recursive<T, Compare, Get, Set>(start + half, len - half, compare, get, set);
				T[] sorted = new T[len];
				int i = start;
				int j = start + half;
				int k = 0;
				while (i < start + half && j < start + len)
				{
					if (compare.Do(get.Do(i), get.Do(j)) == Greater)
					{
						sorted[k++] = get.Do(j++);
					}
					else
					{
						sorted[k++] = get.Do(i++);
					}
				}
				for (int h = 0; h < start + half - i; h++)
				{
					sorted[k + h] = get.Do(i + h);
				}
				for (int h = 0; h < start + len - j; h++)
				{
					sorted[k + h] = get.Do(j + h);
				}
				for (int h = 0; h < len; h++)
				{
					set.Do(start + h, sorted[0 + h]);
				}
			}
		}

		#endregion

		#region Heap

		/// <summary>Sorts values using the heap sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Heap<T>(T[] array) =>
			Heap(array, Compare.Default);

		/// <summary>Sorts values using the heap sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Heap<T>(T[] array, Compare<T> compare) =>
			Heap(array, 0, array.Length, compare);

		/// <summary>Sorts values using the heap sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Heap<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Heap(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the heap sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Heap<T>(T[] array, int start, int end, Compare<T> compare) =>
			Heap<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the heap sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Heap<T, Compare>(T[] array, int start, int end, Compare compare)
			where Compare : struct, ICompare<T> =>
			Heap<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the heap sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Heap<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			Heap<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set);

		/// <summary>Sorts values using the heap sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <runtime>Ω(n*ln(n)), ε(n*ln(n)), O(n^2)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Heap<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			int heapSize = end - start;
			for (int i = (heapSize - 1) / 2; i >= 0; i--)
			{
				MaxHeapify<T, Compare, Get, Set>(heapSize, i, compare, get, set);
			}
			for (int i = end - 1; i > start; i--)
			{
				T temp = get.Do(0);
				set.Do(0, get.Do(i));
				set.Do(i, temp);
				heapSize--;
				MaxHeapify<T, Compare, Get, Set>(heapSize, 0, compare, get, set);
			}
		}

		internal static void MaxHeapify<T, Compare, Get, Set>(int heapSize, int index, Compare compare, Get get, Set set)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			int left = (index + 1) * 2 - 1;
			int right = (index + 1) * 2;
			int largest;
			if (left < heapSize && compare.Do(get.Do(left), get.Do(index)) == Greater)
			{
				largest = left;
			}
			else
			{
				largest = index;
			}
			if (right < heapSize && compare.Do(get.Do(right), get.Do(largest)) == Greater)
			{
				largest = right;
			}
			if (largest != index)
			{
				T temp = get.Do(index);
				set.Do(index, get.Do(largest));
				set.Do(largest, temp);
				MaxHeapify<T, Compare, Get, Set>(heapSize, largest, compare, get, set);
			}
		}

		#endregion

		#region OddEven

		/// <summary>Sorts values using the odd even sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void OddEven<T>(T[] array) =>
			OddEven(array, Compare.Default);

		/// <summary>Sorts values using the odd even sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void OddEven<T>(T[] array, Compare<T> compare) =>
			OddEven(array, 0, array.Length, compare);

		/// <summary>Sorts values using the odd even sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void OddEven<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			OddEven(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the odd even sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void OddEven<T>(T[] array, int start, int end, Compare<T> compare) =>
			OddEven<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the odd even sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void OddEven<T, Compare>(T[] array, int start, int end, Compare compare)
			where Compare : struct, ICompare<T> =>
			OddEven<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the odd even sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void OddEven<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			OddEven<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set);

		/// <summary>Sorts values using the odd even sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <runtime>Ω(n), ε(n^2), O(n^2)</runtime>
		/// <stability>True</stability>
		/// <memory>O(1)</memory>
		public static void OddEven<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			bool sorted = false;
			while (!sorted)
			{
				sorted = true;
				for (int i = start + 1; i < end - 1; i += 2)
				{
					if (compare.Do(get.Do(i), get.Do(i + 1)) == Greater)
					{
						T temp = get.Do(i);
						set.Do(i, get.Do(i + 1));
						set.Do(i + 1, temp);
						sorted = false;
					}
				}
				for (int i = start; i < end - 1; i += 2)
				{
					if (compare.Do(get.Do(i), get.Do(i + 1)) == Greater)
					{
						T temp = get.Do(i);
						set.Do(i, get.Do(i + 1));
						set.Do(i + 1, temp);
						sorted = false;
					}
				}
			}
		}

		#endregion

		#region Counting

#if false

		///// <summary>Method specifically for computing object keys in the Counting Sort algorithm.</summary>
		///// <typeparam name="T">The type of instances in the array to be sorted.</typeparam>
		///// <param name="instance">The instance to compute a counting key for.</param>
		///// <returns>The counting key computed from the provided instance.</returns>
		//public delegate int ComputeCountingKey(T instance);

		///// <summary>Sorts an entire array in non-decreasing order using the heap sort algorithm.</summary>
		///// <typeparam name="T">The type of objects stored within the array.</typeparam>
		///// <param name="computeCountingKey">Method specifically for computing object keys in the Counting Sort algorithm.</param>
		///// <param name="array">The array to be sorted</param>
		///// <runtime>Θ(Max(key)). Memory: Max(key). Stablity: yes</runtime>
		//public static void Counting(ComputeCountingKey computeCountingKey, T[] array)
		//{
		//	throw new System.NotImplementedException();

		//	// This code needs revision and conversion
		//	int[] count = new int[array.Length];
		//	int maxKey = 0;
		//	for (int i = 0; i < array.Length; i++)
		//	{
		//		int key = computeCountingKey(array[i]) / array.Length;
		//		count[key] += 1;
		//		if (key > maxKey)
		//			maxKey = key;
		//	}

		//	int total = 0;
		//	for (int i = 0; i < maxKey; i++)
		//	{
		//		int oldCount = count[i];
		//		count[i] = total;
		//		total += oldCount;
		//	}

		//	T[] output = new T[maxKey];
		//	for (int i = 0; i < array.Length; i++)
		//	{
		//		int key = computeCountingKey(array[i]);
		//		output[count[key]] = array[i];
		//		count[computeCountingKey(array[i])] += 1;
		//	}
		//}

		///// <summary>Sorts an entire array in non-decreasing order using the heap sort algorithm.</summary>
		///// <typeparam name="T">The type of objects stored within the array.</typeparam>
		///// <param name="computeCountingKey">Method specifically for computing object keys in the Counting Sort algorithm.</param>
		///// <param name="array">The array to be sorted</param>
		///// <runtime>Θ(Max(key)). Memory: Max(key). Stablity: yes</runtime>
		//public static void Counting(ComputeCountingKey computeCountingKey, T[] array, int start, int end)
		//{
		//	throw new System.NotImplementedException();
		//}

		///// <summary>Sorts an entire array in non-decreasing order using the heap sort algorithm.</summary>
		///// <typeparam name="T">The type of objects stored within the array.</typeparam>
		///// <param name="computeCountingKey">Method specifically for computing object keys in the Counting Sort algorithm.</param>
		///// <param name="array">The array to be sorted</param>
		///// <runtime>Θ(Max(key)). Memory: Max(key). Stablity: yes</runtime>
		//public static void Counting(ComputeCountingKey computeCountingKey, Get<T> get, Assign<T> set, int start, int end)
		//{
		//	throw new System.NotImplementedException();
		//}

#endif

		#endregion

		#region Shuffle

		/// <summary>Sorts values into a randomized order.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to shuffle.</param>
		/// <param name="random">The random to shuffle with.</param>
		/// <runtime>O(n)</runtime>
		/// <memory>O(1)</memory>
		public static void Shuffle<T>(T[] array, Random random = null) =>
			Shuffle(array, 0, array.Length - 1, random);

		/// <summary>Sorts values into a randomized order.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to shuffle.</param>
		/// <param name="start">The starting index of the shuffle.</param>
		/// <param name="end">The ending index of the shuffle.</param>
		/// <param name="random">The random to shuffle with.</param>
		/// <runtime>O(n)</runtime>
		/// <memory>O(1)</memory>
		public static void Shuffle<T>(T[] array, int start, int end, Random random = null) =>
			Shuffle<T, GetIndexArray<T>, SetIndexArray<T>>(start, end, array, array, random);

		/// <summary>Sorts values into a randomized order.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="random">The random to shuffle with.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the shuffle.</param>
		/// <param name="end">The ending index of the shuffle.</param>
		/// <runtime>O(n)</runtime>
		/// <memory>O(1)</memory>
		public static void Shuffle<T>(int start, int end, GetIndex<T> get, SetIndex<T> set, Random random = null) =>
			Shuffle<T, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, get, set, random);

		/// <summary>Sorts values into a randomized order.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the shuffle.</param>
		/// <param name="end">The ending index of the shuffle.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="random">The random to shuffle with.</param>
		/// <runtime>O(n)</runtime>
		/// <memory>O(1)</memory>
		public static void Shuffle<T, Get, Set>(int start, int end, Get get = default, Set set = default, Random random = null)
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			random ??= new Random();
			for (int i = start; i <= end; i++)
			{
				int randomIndex = random.Next(start, end);
				T temp = get.Do(i);
				set.Do(i, get.Do(randomIndex));
				set.Do(randomIndex, temp);
			}
		}

		#endregion

		#region Bogo

		/// <summary>Sorts values using the bogo sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="random">The random to use while sorting.</param>
		/// <runtime>Ω(n), ε(n*n!), O(∞)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Bogo<T>(T[] array, Random random = null) =>
			Bogo(array, Compare.Default, random);

		/// <summary>Sorts values using the bogo sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="random">The random to use while sorting.</param>
		/// <runtime>Ω(n), ε(n*n!), O(∞)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Bogo<T>(T[] array, Compare<T> compare, Random random = null) =>
			Bogo(array, 0, array.Length - 1, compare, random);

		/// <summary>Sorts values using the bogo sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="random">The random to use while sorting.</param>
		/// <runtime>Ω(n), ε(n*n!), O(∞)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Bogo<T, Compare>(T[] array, Compare compare = default, Random random = null)
			where Compare : struct, ICompare<T> =>
			Bogo(array, 0, array.Length - 1, compare, random);

		/// <summary>Sorts values using the bogo sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="random">The random to use while sorting.</param>
		/// <runtime>Ω(n), ε(n*n!), O(∞)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Bogo<T>(T[] array, int start, int end, Compare<T> compare, Random random = null) =>
			Bogo<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array, random);

		/// <summary>Sorts values using the bogo sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="random">The random to use while sorting.</param>
		/// <runtime>Ω(n), ε(n*n!), O(∞)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Bogo<T, Compare>(T[] array, int start, int end, Compare compare, Random random = null)
			where Compare : struct, ICompare<T> =>
			Bogo<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array, random);

		/// <summary>Sorts values using the bogo sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="random">The random to use while sorting.</param>
		/// <runtime>Ω(n), ε(n*n!), O(∞)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Bogo<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set, Random random = null) =>
			Bogo<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set, random);

		/// <summary>Sorts values using the bogo sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		/// <param name="random">The random to use while sorting.</param>
		/// <runtime>Ω(n), ε(n*n!), O(∞)</runtime>
		/// <stability>False</stability>
		/// <memory>O(1)</memory>
		public static void Bogo<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default, Random random = null)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			random ??= new Random();
			while (!BogoCheck<T, Compare, Get>(start, end, compare, get))
			{
				Shuffle<T, Get, Set>(start, end, get, set, random);
			}
		}

		internal static bool BogoCheck<T, Compare, Get>(int start, int end, Compare compare, Get get)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
		{
			for (int i = start; i <= end - 1; i++)
			{
				if (compare.Do(get.Do(i), get.Do(i + 1)) == Greater)
				{
					return false;
				}
			}
			return true;
		}

		#endregion

		#region Slow

		/// <summary>Sorts values using the slow sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		public static void Slow<T>(T[] array) =>
			Slow(array, Compare.Default);

		/// <summary>Sorts values using the slow sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		public static void Slow<T>(T[] array, Compare<T> compare) =>
			Slow(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the slow sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="compare">The compare function.</param>
		public static void Slow<T, Compare>(T[] array, Compare compare = default)
			where Compare : struct, ICompare<T> =>
			Slow(array, 0, array.Length - 1, compare);

		/// <summary>Sorts values using the slow sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		public static void Slow<T>(T[] array, int start, int end, Compare<T> compare) =>
			Slow<T, CompareRuntime<T>, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the slow sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <param name="array">The array to be sorted.</param>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		public static void Slow<T, Compare>(T[] array, int start, int end, Compare compare)
			where Compare : struct, ICompare<T> =>
			Slow<T, Compare, GetIndexArray<T>, SetIndexArray<T>>(start, end, compare, array, array);

		/// <summary>Sorts values using the slow sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		public static void Slow<T>(int start, int end, Compare<T> compare, GetIndex<T> get, SetIndex<T> set) =>
			Slow<T, CompareRuntime<T>, GetIndexRuntime<T>, SetIndexRuntime<T>>(start, end, compare, get, set);

		/// <summary>Sorts values using the slow sort algorithm.</summary>
		/// <typeparam name="T">The type of values to sort.</typeparam>
		/// <typeparam name="Compare">The compare function.</typeparam>
		/// <typeparam name="Get">The get function.</typeparam>
		/// <typeparam name="Set">The set function.</typeparam>
		/// <param name="start">The starting index of the sort.</param>
		/// <param name="end">The ending index of the sort.</param>
		/// <param name="compare">The compare function.</param>
		/// <param name="get">The get function.</param>
		/// <param name="set">The set function.</param>
		public static void Slow<T, Compare, Get, Set>(int start, int end, Compare compare = default, Get get = default, Set set = default)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T> =>
			Slow_Recursive<T, Compare, Get, Set>(start, end, compare, get, set);

		internal static void Slow_Recursive<T, Compare, Get, Set>(int i, int j, Compare compare, Get get, Set set)
			where Compare : struct, ICompare<T>
			where Get : struct, IGetIndex<T>
			where Set : struct, ISetIndex<T>
		{
			if (i >= j)
			{
				return;
			}
			int m = (i + j) / 2;
			Slow_Recursive<T, Compare, Get, Set>(i, m, compare, get, set);
			Slow_Recursive<T, Compare, Get, Set>(m + 1, j, compare, get, set);
			if (compare.Do(get.Do(j), get.Do(m)) == Less)
			{
				T temp = get.Do(j);
				set.Do(j, get.Do(m));
				set.Do(m, temp);
			}
			Slow_Recursive<T, Compare, Get, Set>(i, j - 1, compare, get, set);
		}

		#endregion
	}
}
