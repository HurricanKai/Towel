﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Towel;
using Towel.DataStructures;

namespace Towel_Testing.DataStructures
{
	public static class IStackTester
	{
		private static void Push_Pop_Testing<T, Stack>(T[] values)
			where Stack : IStack<T>, new()
		{
			{ // push && pop
				Sort.Shuffle(values);
				IStack<T> stack = new Stack();
				values.Stepper(x => stack.Push(x));
				Assert.IsTrue(stack.Count == values.Length);
				Array.Reverse(values);
				values.Stepper(x => Assert.IsTrue(x.Equals(stack.Pop())));
			}
			{ // exceptions
				IStack<T> stack = new Stack();
				Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
			}
		}

		public static void Push_Pop_Int32_Testing<Stack>()
			where Stack : IStack<int>, new()
		{
			const int count = 10000;
			int[] values = new int[count];
			Stepper.Iterate(count, i => values[i] = i);
			Push_Pop_Testing<int, Stack>(values);
		}

		public static void Push_Pop_String_Testing<Stack>()
			where Stack : IStack<string>, new()
		{
			const int count = 10000;
			string[] values = new string[count];
			Stepper.Iterate(count, i => values[i] = i.ToString());
			Push_Pop_Testing<string, Stack>(values);
		}

		public static void Stepper_Testing<Stack>()
			where Stack : IStack<int>, new()
		{
			{ // push only
				int[] values = { 0, 1, 2, 3, 4, 5, };
				IStack<int> stack = new Stack();
				values.Stepper(i => stack.Push(i));
				Assert.IsTrue(stack.Stepper().Count() == values.Length);
				ISet<int> set = new SetHashLinked<int>();
				values.Stepper(i => set.Add(i));
				stack.Stepper(i =>
				{
					Assert.IsTrue(set.Contains(i));
					set.Remove(i);
				});
				Assert.IsTrue(set.Count == 0);
			}
			{ // push + pop
				int[] values = { 0, 1, 2, 3, 4, 5, };
				int[] expectedValues = { 0, 1, 2, 3, };
				IStack<int> stack = new Stack();
				values.Stepper(i => stack.Push(i));
				stack.Pop();
				stack.Pop();
				Assert.IsTrue(stack.Stepper().Count() == expectedValues.Length);
				ISet<int> set = new SetHashLinked<int>();
				expectedValues.Stepper(i => set.Add(i));
				stack.Stepper(i =>
				{
					Assert.IsTrue(set.Contains(i));
					set.Remove(i);
				});
				Assert.IsTrue(set.Count == 0);
			}
			{ // push + pop
				int[] values = { 0, 1, 2, 3, 4, 5, };
				IStack<int> stack = new Stack();
				values.Stepper(i => stack.Push(i));
				values.Stepper(i =>
				{
					stack.Pop();
					stack.Push(i);
				});
				Assert.IsTrue(stack.Stepper().Count() == values.Length);
				ISet<int> set = new SetHashLinked<int>();
				values.Stepper(i => set.Add(i));
				stack.Stepper(i =>
				{
					Assert.IsTrue(set.Contains(i));
					set.Remove(i);
				});
				Assert.IsTrue(set.Count == 0);
			}
		}

		public static void IEnumerable_Testing<Stack>()
			where Stack : IStack<int>, new()
		{
			{ // push only
				int[] values = { 0, 1, 2, 3, 4, 5, };
				IStack<int> stack = new Stack();
				values.Stepper(i => stack.Push(i));
				Assert.IsTrue(System.Linq.Enumerable.Count(stack) == values.Length);
				ISet<int> set = new SetHashLinked<int>();
				values.Stepper(i => set.Add(i));
				foreach (int i in stack)
				{
					Assert.IsTrue(set.Contains(i));
					set.Remove(i);
				}
				Assert.IsTrue(set.Count == 0);
			}
			{ // push + pop
				int[] values = { 0, 1, 2, 3, 4, 5, };
				int[] expectedValues = { 0, 1, 2, 3, };
				IStack<int> stack = new Stack();
				values.Stepper(i => stack.Push(i));
				stack.Pop();
				stack.Pop();
				Assert.IsTrue(System.Linq.Enumerable.Count(stack) == expectedValues.Length);
				ISet<int> set = new SetHashLinked<int>();
				expectedValues.Stepper(i => set.Add(i));
				foreach (int i in stack)
				{
					Assert.IsTrue(set.Contains(i));
					set.Remove(i);
				};
				Assert.IsTrue(set.Count == 0);
			}
			{ // push + pop
				int[] values = { 0, 1, 2, 3, 4, 5, };
				IStack<int> stack = new Stack();
				values.Stepper(i => stack.Push(i));
				values.Stepper(i =>
				{
					stack.Pop();
					stack.Push(i);
				});
				Assert.IsTrue(System.Linq.Enumerable.Count(stack) == values.Length);
				ISet<int> set = new SetHashLinked<int>();
				values.Stepper(i => set.Add(i));
				foreach (int i in stack)
				{
					Assert.IsTrue(set.Contains(i));
					set.Remove(i);
				};
				Assert.IsTrue(set.Count == 0);
			}
		}
	}

	[TestClass] public class StackArray_Testing
	{
		[TestMethod] public void Push_Pop_Testing()
		{
			IStackTester.Push_Pop_Int32_Testing<StackArray<int>>();
			IStackTester.Push_Pop_String_Testing<StackArray<string>>();
		}

		[TestMethod] public void Stepper_Testing()
		{
			IStackTester.Stepper_Testing<StackArray<int>>();
		}

		[TestMethod] public void IEnumerable_Testing()
		{
			IStackTester.IEnumerable_Testing<StackArray<int>>();
		}
	}

	[TestClass] public class StackLinked_Testing
	{
		[TestMethod] public void Push_Pop_Testing()
		{
			IStackTester.Push_Pop_Int32_Testing<StackLinked<int>>();
			IStackTester.Push_Pop_String_Testing<StackLinked<string>>();
		}

		[TestMethod] public void Stepper_Testing()
		{
			IStackTester.Stepper_Testing<StackLinked<int>>();
		}

		[TestMethod] public void IEnumerable_Testing()
		{
			IStackTester.IEnumerable_Testing<StackLinked<int>>();
		}
	}
}
