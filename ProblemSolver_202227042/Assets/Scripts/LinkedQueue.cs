using UnityEngine;

public class LinkedQueue : MonoBehaviour
{
    public class Node<T>
    {
        //������ ������
        public T Data { get; set; }
        // ���� ��带 ����Ű�� ����
        public Node<T> Next { get; set; }
        // ������
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // ���׸� ��ũ�� ����Ʈ ť
    public class LinkQueue<T>
    {
        // ť�� �� �� ���
        public Node<T> head;
        // ť�� �� �� ���
        public Node<T> tail;

        // ������
        public LinkQueue()
        {
            head = null;
            tail = null;
        }

        // ť�� ����ִ��� Ȯ��
        public bool IsEmpty()
        {
            return head == null;
        }

        // ť�� �� �ڿ� ���ο� ������ �߰�
        public void Enqueue(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        // ť�� �� �� ������ ����, ��ȯ
        public T Dequeue()
        {
            if (IsEmpty())
            {
                Debug.Log("Queue�� �������");  
                return default(T);
            }

            T value = head.Data;
            head = head.Next;

            if (head == null)
                tail = null;

            return value;
        }

        // ť�� �� �� �����͸� ��ȯ
        public T Peek()
        {
            if (IsEmpty())
            {
                Debug.Log("Queue�� �������");
                return default(T);
            }
            return head.Data;
        }
    }
}
