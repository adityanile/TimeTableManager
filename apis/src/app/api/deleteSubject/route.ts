import { SubjectData } from "@/app/types";
import { NextResponse } from "next/server";
import prisma from "@/lib/prisma";
import { Prisma } from "@prisma/client";

export async function POST(request: Request) {
  const { id } = await request.json();

  if (!id) return NextResponse.json({ status: "Fail", msg: "Invalid Params" });

  let res;

  try {
    res = await prisma.subjects.delete({
      where: {
        id: id,
      },
    });
  } catch (e) {
    if (e instanceof Prisma.PrismaClientKnownRequestError) {
      return NextResponse.json({ status: "fail", e });
    }
  }

  if (!res) return NextResponse.json({ status: "fail", msg: "No Itme Found" });

  return NextResponse.json({
    status: "success",
    msg: "Deleted Subject Id : " + res.id,
  });
}
